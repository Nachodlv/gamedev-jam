using System;
using Entities;
using UnityEngine;

namespace Levels
{
	public class MapLimit : MonoBehaviour
	{
		private void OnTriggerExit2D(Collider2D other)
		{
			var damageReceiver = other.GetComponent<DamageReceiver>();
			if (damageReceiver == null) return;
			damageReceiver.ReceiveDamage(0, Vector3.zero, true);
		}
	}
}