using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

namespace Entities.Player
{
	public class APlayer : DamageReceiver, IHaveStats
	{
		[SerializeField] private Stats stats;

		public event Action OnDie;

		private bool _dead;
		
		public Stats Stats => stats;
		
		
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