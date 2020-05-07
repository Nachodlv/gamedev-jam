using System;
using DefaultNamespace;
using Enemy.Ai;
using Entities;
using UnityEngine;

namespace Enemy
{
	public class AEnemy: DamageReceiver, IHaveStats, IPausable
	{
		[SerializeField] private Stats stats;
		public Stats Stats => stats;


		protected override void Awake()
		{
			base.Awake();
		}

		protected override void DealDamage(float damage, bool instantKill)
		{
			stats.CurrentHealth = instantKill? 0 : stats.CurrentHealth - damage;
		}

		public void Pause()
		{
			Debug.Log($"{gameObject.name} I am paused!");
		}

		public void UnPause()
		{
			Debug.Log($"{gameObject.name} I am upaused!");

		}
	}
}