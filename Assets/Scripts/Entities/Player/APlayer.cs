using System;
using System.Collections;
using Entities.Player.Abilities;
using UI;
using UnityEngine;

namespace Entities.Player
{
    [RequireComponent(typeof(TimeStopAbility), typeof(DashAbility))]
    public class APlayer : DamageReceiver, IHaveStats
    {
        [SerializeField] private Stats stats;
        [SerializeField] private SpritesProgressBar healthDiplayer;
        [SerializeField, Range(0, 1)] private float lowHealthPercentage = 0.2f;

        public event Action OnDie;
        public event Action OnResetLevel;
        public event Action<bool> OnLowHealth;
        public Stats Stats => stats;
        public TimeStopAbility TimeStopAbility { get; private set; }
        public DashAbility DashAbility { get; private set; }

        public int RetryQuantity { get; private set; }

        private float _maxHealth;
        private bool _onLowHealth;

        protected override void Awake()
        {
            base.Awake();
            TimeStopAbility = GetComponent<TimeStopAbility>();
            DashAbility = GetComponent<DashAbility>();
        }

        private void Update()
        {
            if (Dead) return;
            UpdateHealth(stats.Health - Time.deltaTime);
        }

        public void StartLevel(float time, int retryQuantity)
        {
            Dead = false;
            _maxHealth = time;
            stats.Health = time;
            healthDiplayer.SetUpMaxValue(time);
            RetryQuantity = retryQuantity;
        }

        public void UpdateHealth(float newHealth)
        {
            stats.Health = newHealth;
            healthDiplayer.UpdateValue(stats.Health);
            if (stats.Health <= 0)
            {
                Dead = true;
                StartCoroutine(WaitForAnimationToEnd());
                return;
            }
            if (_maxHealth * lowHealthPercentage > newHealth)
            {
                if (!_onLowHealth)
                {
                    _onLowHealth = true;
                    OnLowHealth?.Invoke(true);
                }
            }
            else if (_onLowHealth)
            {
                _onLowHealth = false;
                OnLowHealth?.Invoke(false);
            }
        }

        protected override bool DealDamage(float damage, bool instantKill)
        {
            if (Dead) return true;
            UpdateHealth(instantKill ? 0 : stats.Health - damage);
            return stats.Health <= 0;
        }

        private IEnumerator WaitForAnimationToEnd()
        {
            OnDie?.Invoke();
            RigidBody2D.velocity = Vector2.zero;
            yield return new WaitForSeconds(1.67f);
            OnResetLevel?.Invoke();
            ResetPlayer();
        }

        private void ResetPlayer()
        {
            TimeStopAbility.UnPause();
        }
    }
}