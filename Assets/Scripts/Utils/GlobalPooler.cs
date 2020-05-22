using System;
using System.Collections.Generic;
using Entities.Enemy;
using Entities.Grabbables;
using Levels;
using UnityEngine;

namespace Utils
{
	[Serializable]
	public class Pool
	{
		public int quantity;
		public GameObject prefab;
		public PoolType poolType;
		public enum PoolType
		{
			Battery,
			BlueCannon,
			RedCannon,
			Laser,
			GreenCannon
		}
	}

	public class GlobalPooler : MonoBehaviour
	{
		[SerializeField] private Pool batteryPool;
		[SerializeField] private Pool[] bulletPools;
		[SerializeField] private LevelManager levelManager;

		public MiniBattery NextMiniBattery => _miniBattteryPooler.GetNextObject();
		public static GlobalPooler Instance;

		private ObjectPooler<MiniBattery> _miniBattteryPooler;
		private Dictionary<Pool.PoolType, ObjectPooler<Bullet>> _bulletPools;
		
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
			levelManager.OnLevelChange += (settings) => DeactivatePools();
			InitializeBulletPools();
		}

		public Bullet GetBullet(Pool.PoolType poolType) => _bulletPools[poolType].GetNextObject();
		
		private ObjectPooler<T> CreatePool<T>(Pool pool) where T : Pooleable
		{
			var objectPooler = new ObjectPooler<T>();
			objectPooler.InstantiateObjects(pool.quantity, pool.prefab.GetComponent<T>(),
				$"Pool of {pool.prefab.name}");
			return objectPooler;
		}

		private void InitializeBulletPools()
		{
			_bulletPools = new Dictionary<Pool.PoolType, ObjectPooler<Bullet>>();
			foreach (var bulletPool in bulletPools)
			{
				_bulletPools[bulletPool.poolType] = CreatePool<Bullet>(bulletPool);
			}
		}
		
		private void DeactivatePools()
		{
			_miniBattteryPooler.DeactivatePooleables();
			foreach (var pools in _bulletPools)
			{
				pools.Value.DeactivatePooleables();
			}
		}
	}
}