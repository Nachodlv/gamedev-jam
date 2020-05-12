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
		
		protected override void DealDamage(float damage, bool instantKill)
		{
			stats.Health = instantKill? 0 : stats.Health - damage;
			if(stats.Health <= 0) Die();
		}
		

		private void Die()
		{
			OnDie?.Invoke();
			gameObject.SetActive(false);
		}
	}
}