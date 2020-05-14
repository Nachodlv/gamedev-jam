using System;
using DefaultNamespace;
using UnityEngine;

namespace Entities.Enemy
{
	public class AEnemy: DamageReceiver, IHaveStats
	{
		[SerializeField] private Stats stats;
		public Stats Stats => stats;
		public event Action OnDie;

		protected override bool DealDamage(float damage, bool instantKill)
		{
			stats.Health = instantKill? 0 : stats.Health - damage;
			if (stats.Health > 0) return false;
			
			Die();
			return true;

		}
		
		private void Die()
		{
			OnDie?.Invoke();
		}
	}
}