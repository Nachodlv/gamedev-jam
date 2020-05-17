using System;
using UnityEngine;
using Utils;
using CharacterController = Entities.Player.Movement.CharacterController;

namespace Entities.Player.Abilities
{
	[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(DamageReceiver))]
	public class DashAbility : MonoBehaviour
	{
		[SerializeField] private CharacterController _characterController;
		[SerializeField] private float distance = 2f;
		[SerializeField] private LayerMask collisionMask;
		[SerializeField] private float damage = 4f;
		[SerializeField] private float timeBetweenDashes = 1f;
		[SerializeField] private float invincibleTime = 0.5f;

		public event Action OnDash;
		
		private bool _hasDashed;
		private RaycastHit2D[] _hits;
		private Collider2D _collider;
		private Rigidbody2D _rigidBody;
		private float _lastDash;
		private DamageReceiver _damageReceiver;
		private WaitSeconds _invincibleWaitTime;

		private void Awake()
		{
			_characterController.OnJumpEvent += OnJump;
			_hits = new RaycastHit2D[10];
			_collider = GetComponent<Collider2D>();
			_rigidBody = GetComponent<Rigidbody2D>();
			_damageReceiver = GetComponent<DamageReceiver>();
			_invincibleWaitTime = 
				new WaitSeconds(this, () => _damageReceiver.Invincible = false, invincibleTime);
		}

		public void Dash()
		{
			if (!CanDash()) return;
			_damageReceiver.Invincible = true;
			_invincibleWaitTime.Wait();
			_hasDashed = true;
			_lastDash = Time.time;
			OnDash?.Invoke();
		}

		public void MakeDash()
		{
			var position = transform.position;
			var destination = GetDashDestination(position);
			var size = Physics2D.LinecastNonAlloc(position, destination, _hits, collisionMask);
			IterateThroughColliders(position, destination, size);
		}

		private void IterateThroughColliders(Vector2 position, Vector2 destination, int size)
		{
			for (int i = 0; i < size; i++)
			{
				var damageReceiver = _hits[i].collider.GetComponent<DamageReceiver>();
				if(damageReceiver != null) damageReceiver.ReceiveDamage(damage, position);
				else
				{
					HitWall(_hits[i].point);
					return;
				}
			}
			Debug.DrawLine(position, destination, Color.green, 5);

			_rigidBody.position = destination;
			_rigidBody.velocity = Vector2.zero;
		}
		
 		private Vector2 GetDashDestination(Vector2 position)
		{
			var destination = position;
			var facing = _characterController.FacingRight ? 1 : -1;
			destination.x += distance * facing;
			return destination;
		}
		
		private void HitWall(Vector2 point)
		{
			point.x += _collider.bounds.extents.x * (_characterController.FacingRight? -1 : 1);
			transform.position = point;
			Debug.DrawLine(transform.position, point, Color.red, 5);
		}

		private void OnJump()
		{
			_hasDashed = false;
		}

		private bool CanDash()
		{
			return !_hasDashed || Time.time - _lastDash > timeBetweenDashes;
		}
	}
}