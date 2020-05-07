using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

namespace Entities.Player
{
	[RequireComponent(typeof(TimeStopAbility))]
	public class APlayer : DamageReceiver, IHaveStats
	{
		[SerializeField] private Stats stats;

		public event Action OnDie;
		public Stats Stats => stats;
		public TimeStopAbility TimeStopAbility { get; private set; }

		private bool _dead;

		protected override void Awake()
		{
			base.Awake();
			TimeStopAbility = GetComponent<TimeStopAbility>();
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
			_dead = false;
			stats.ResetHealth();
		}
	}
}