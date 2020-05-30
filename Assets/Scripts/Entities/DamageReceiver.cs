using System;
using System.Collections;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class DamageReceiver : MonoBehaviour
    {
        [SerializeField] private float forceAppliedOnHit = 1f;
        [SerializeField] private float invincibleTime = 1f;
        [SerializeField] private float timeBetweenBlinks = 0.2f;
        [SerializeField] private SpriteRenderer[] spriteRenderers;

        public bool Invincible { get; set; }
        public event Action OnDamageReceive;

        protected Rigidbody2D RigidBody2D { get; private set; }
        protected bool Dead { get; set; }

        private WaitForSeconds _timeBetweenBlinks;
        private Func<IEnumerator> _blinkFunction;
        private Coroutine _blinkCoroutine;

        protected virtual void Awake()
        {
            RigidBody2D = GetComponent<Rigidbody2D>();
            _timeBetweenBlinks = new WaitForSeconds(timeBetweenBlinks);
            _blinkFunction = StartBlinking;
        }

        public void ReceiveDamage(float damage, Vector3 positionAttacker, bool instantKill = false,
            bool overrideInvincible = false)
        {
            if ((Invincible && !overrideInvincible) || Dead) return;
            OnDamageReceive?.Invoke();
            Dead = DealDamage(damage, instantKill);
            if (Dead) return;

            _blinkCoroutine = StartCoroutine(_blinkFunction());

            var direction = (transform.position - positionAttacker).normalized;
            RigidBody2D.AddForce(direction * forceAppliedOnHit);
        }

        protected abstract bool DealDamage(float damage, bool instantKill);

        private IEnumerator StartBlinking()
        {
            Invincible = true;
            var now = Time.time;
            var hide = false;
            while (Time.time - now < invincibleTime)
            {
                hide = !hide;
                ChangeAlphaSpriteRender(hide);
                yield return _timeBetweenBlinks;
            }

            Invincible = false;
            ChangeAlphaSpriteRender(false);
        }


        private void ChangeAlphaSpriteRender(bool hide)
        {
            for (var i = 0; i < spriteRenderers.Length; i++)
            {
                var color = spriteRenderers[i].color;
                color.a = hide ? 0 : 1;
                spriteRenderers[i].color = color;
            }
        }

        private void OnDestroy()
        {
            if (_blinkCoroutine != null) StopCoroutine(_blinkCoroutine);
        }
    }
}