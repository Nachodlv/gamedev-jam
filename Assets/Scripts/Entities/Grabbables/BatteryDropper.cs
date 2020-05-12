using System;
using Entities.Enemy;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Entities.Grabbables
{
	[RequireComponent(typeof(AEnemy))]
	public class BatteryDropper : MonoBehaviour
	{
		[SerializeField] private int minQuantity = 1;
		[SerializeField] private int maxQuantity = 1;
		[SerializeField] private float healthRestore = 10;
		[SerializeField] private float dropForce = 1f;
		
		private void Awake()
		{
			GetComponent<AEnemy>().OnDie += DropBatteries;
		}

		private void DropBatteries()
		{
			var quantity = Random.Range(minQuantity, maxQuantity);
			var position = transform.position;
			for (var i = 0; i < quantity; i++)
			{
				var miniBattery = GlobalPooler.Instance.NextMiniBattery;
				miniBattery.transform.position = position;
				miniBattery.HealthQuantity = healthRestore;
				miniBattery.Rigidbody2D.AddForce(new Vector2(Random.Range(-dropForce, dropForce), dropForce));
			}
		}
	}
}