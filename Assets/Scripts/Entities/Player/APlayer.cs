using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

namespace Entities.Player
{
	[RequireComponent(typeof(TimeStopAbility), typeof(DashAbility))]
	public class APlayer : DamageReceiver, IHaveStats
	{
		[SerializeField] private Stats stats;

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

		protected override void DealDamage(float damage, bool instantKill)
		{
			if(_dead) return;
			stats.CurrentHealth = instantKill ? 0 : stats.CurrentHealth - damage;
			if (stats.CurrentHealth <= 0)
			{
				_dead = true;
				StartCoroutine(WaitForAnimationToEnd());
			}
		}

		private IEnumerator WaitForAnimationToEnd()
		{
			yield return new WaitForSeconds(0.2f);
			OnDie?.Invoke();
			ResetPlayer();
		}

		private void ResetPlayer()
		{
			_dead = false;
			stats.ResetHealth();
			TimeStopAbility.UnPause();
		}
	}
}