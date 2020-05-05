using System;
using UnityEngine;

namespace DefaultNamespace
{
	[RequireComponent(typeof(Rigidbody2D))]
	public abstract class DamageReceiver: MonoBehaviour
	{
		[SerializeField] private float forceAppliedOnHit = 1f;
		
		private Rigidbody2D _rigidbody2D;

		private void Awake()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		public void ReceiveDamage(float damage, Vector3 positionAttacker)
		{
			DealDamage(damage);
			var direction = (transform.position - positionAttacker).normalized;
			_rigidbody2D.AddForce(direction * forceAppliedOnHit);
		}

		protected abstract void DealDamage(float damage);
	}
}