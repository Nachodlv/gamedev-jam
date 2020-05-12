using System;
using System.Collections;
using DefaultNamespace;
using UI;
using UnityEngine;

namespace Entities.Player
{
	[RequireComponent(typeof(TimeStopAbility), typeof(DashAbility))]
	public class APlayer : DamageReceiver, IHaveStats
	{
		[SerializeField] private Stats stats;
		[SerializeField] private HealthDisplayer healthDiplayer;
		
		public event Action OnDie;
		public Stats Stats => stats;
		public TimeStopAbility TimeStopAbility { get; private set; }
		public DashAbility DashAbility { get; private set; }

		private bool _dead;

		protected override void Awake()
		{
			base.Awake();
			TimeStopAbility = GetComponent<TimeStopAbility>();
			DashAbility = GetComponent<DashAbility>();
		}

		private void Update()
		{
			if (_dead) return;
			UpdateHealth(stats.Health - Time.deltaTime);
			if (stats.Health <= 0)
			{
				_dead = true;
				StartCoroutine(WaitForAnimationToEnd());
			}
		}

		public void StartLevel(float time)
		{
			_dead = false;
			stats.Health = time;
			healthDiplayer.SetUpMaxHealth(time);
		}

		public void UpdateHealth(float newHealth)
		{
			stats.Health = newHealth;
			healthDiplayer.UpdateHealth(stats.Health);
		}

		protected override void DealDamage(float damage, bool instantKill)
		{
			if(_dead) return;
			stats.Health = instantKill ? 0 : stats.Health - damage;
		}

		private IEnumerator WaitForAnimationToEnd()
		{
			yield return new WaitForSeconds(0.2f);
			OnDie?.Invoke();
			ResetPlayer();
		}

		private void ResetPlayer()
		{
			TimeStopAbility.UnPause();
		}
	}
}