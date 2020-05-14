﻿using System;
using System.Collections.Generic;
using Entities.Grabbables;
using UnityEngine;

namespace Utils
{
	[Serializable]
	public class Pool
	{
		public int quantity;
		public GameObject prefab;

		public enum PoolType
		{
			Battery
		}
	}

	public class GlobalPooler : MonoBehaviour
	{
		[SerializeField] private Pool batteryPool;

		public MiniBattery NextMiniBattery => _miniBattteryPooler.GetNextObject();
		public static GlobalPooler Instance;

		private ObjectPooler<MiniBattery> _miniBattteryPooler;
		
		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(this);
				return;
			}
			_miniBattteryPooler = CreatePool<MiniBattery>(batteryPool);
		}

		private ObjectPooler<T> CreatePool<T>(Pool pool) where T : Pooleable
		{
			var objectPooler = new ObjectPooler<T>();
			objectPooler.InstantiateObjects(pool.quantity, pool.prefab.GetComponent<T>(),
				$"Pool of {pool.prefab.name}");
			return objectPooler;
		}
	}
}