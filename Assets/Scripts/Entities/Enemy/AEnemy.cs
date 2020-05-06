using System;
using DefaultNamespace;
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
		}
	}
}