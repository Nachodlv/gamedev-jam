using System;
using DefaultNamespace;
using Enemy.Ai;
using Entities;
using UnityEngine;

namespace Enemy
{
	public class AEnemy: DamageReceiver, IHaveStats
	{
		[SerializeField] private Stats stats;
		public Stats Stats => stats;
		
		protected override void DealDamage(float damage, bool instantKill)
		{
			stats.CurrentHealth = instantKill? 0 : stats.CurrentHealth - damage;
			if(stats.CurrentHealth <= 0) Die();
		}
		

		private void Die()
		{
			gameObject.SetActive(false);
		}
	}
}