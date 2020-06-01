using System;
using Cinemachine;
using UnityEngine;
using Utils;
using CharacterController = Entities.Player.Movement.CharacterController;

namespace Entities.Player.Abilities
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(DamageReceiver))]
    public class DashAbility : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float distance = 2f;
        [SerializeField] private LayerMask collisionMask;
        [SerializeField] private float damage = 4f;
        [SerializeField] private float timeBetweenDashes = 1f;
        [SerializeField] private float invincibleTime = 0.5f;

        public event Action OnDash;
        public float LastDash { get; private set; }
        public float TimeBetweenDashes => timeBetweenDashes;

        // private bool _hasDashed;
        private RaycastHit2D[] _hits;
        private Collider2D _collider;
        private Rigidbody2D _rigidBody;
        private DamageReceiver _damageReceiver;
        private WaitSeconds _invincibleWaitTime;
        private CinemachineFramingTransposer _camera;

        private void Awake()
        {
            _camera = FindObjectOfType<CinemachineVirtualCamera>()
                .GetCinemachineComponent<CinemachineFramingTransposer>();
            _hits = new RaycastHit2D[10];
            _collider = GetComponent<Collider2D>();
            _rigidBody = GetComponent<Rigidbody2D>();
            _damageReceiver = GetComponent<DamageReceiver>();
            _invincibleWaitTime =
                new WaitSeconds(this, () => _damageReceiver.Invincible = false, invincibleTime);
            LastDash = -timeBetweenDashes;
        }

        public void Dash()
        {
            if (!CanDash()) return;
            _damageReceiver.Invincible = true;
            _invincibleWaitTime.Wait();
            // _hasDashed = true;
            LastDash = Time.time;
            OnDash?.Invoke();
        }

        public void MakeDash()
        {
            var position = (Vector2) transform.position;
            var destination = position;
            var facing = characterController.FacingRight ? 1 : -1;
            destination.x += distance * facing;

            var boxSize = _collider.bounds.size;
            boxSize.x *= 0.2f;
            boxSize.y *= 0.8f;
            var size = Physics2D.BoxCastNonAlloc(position, boxSize, 0f,  destination - position, _hits,
                distance, collisionMask);
            IterateThroughColliders(position, destination, size);
        }

        public void RestoreDash()
        {
            LastDash -= timeBetweenDashes;
        }

        private void IterateThroughColliders(Vector2 position, Vector2 destination, int size)
        {
            for (int i = 0; i < size; i++)
            {
                var damageReceiver = _hits[i].collider.GetComponent<DamageReceiver>();
                if (damageReceiver != null) damageReceiver.ReceiveDamage(damage, position);
                else
                {
                    HitWall(_hits[i].point);
                    return;
                }
            }

            _camera.OnTargetObjectWarped(transform, destination - _rigidBody.position);
            _rigidBody.position = destination;
            // _rigidBody.velocity = Vector2.zero;
        }
        
        private void HitWall(Vector2 point)
        {
            point.x += _collider.bounds.extents.x * (characterController.FacingRight ? -1 : 1);
            transform.position = point;
            Debug.DrawLine(transform.position, point, Color.red, 5);
        }

        private bool CanDash()
        {
            return Time.time - LastDash > timeBetweenDashes;
        }
    }
}