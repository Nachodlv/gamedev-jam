using System;
using UnityEngine;

namespace Entities.Enemy
{
	[RequireComponent(typeof(Collider2D))]
	public class AEnemy: DamageReceiver, IHaveStats
	{
		[SerializeField] private Stats stats;
		public Stats Stats => stats;
		public event Action OnDie;

		private Collider2D _collider;

		protected override void Awake()
		{
			base.Awake();
			_collider = GetComponent<Collider2D>();
		}

		protected override bool DealDamage(float damage, bool instantKill)
		{
			stats.Health = instantKill? 0 : stats.Health - damage;
			if (stats.Health > 0) return false;
			
			Die();
			return true;

		}
		
		private void Die()
		{
			_collider.enabled = false;
			RigidBody2D.isKinematic = true;
			OnDie?.Invoke();
		}
	}
}