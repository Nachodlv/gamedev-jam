using DefaultNamespace;
using UnityEngine;

namespace Enemy
{
	public class AEnemy: DamageReceiver, IHaveStats
	{
		[SerializeField] private Stats stats;
		public Stats Stats => stats;

		protected override void DealDamage(float damage)
		{
			stats.Health -= damage;
		}

	}
}