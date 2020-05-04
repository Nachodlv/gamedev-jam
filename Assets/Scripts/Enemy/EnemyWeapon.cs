using System;
using UnityEngine;

namespace Enemy
{
	public class EnemyWeapon: MonoBehaviour
	{
		[SerializeField] private Bullet bulletPrefab;
		[SerializeField] private float timeBetweenShoots;
		[SerializeField] private Transform shootingPoint;

		private float _lastShoot;
		private Transform _bulletAnchor;

		private void Awake()
		{
			_bulletAnchor = new GameObject("Bullet anchor").transform;
		}

		public void Shoot()
		{
			_lastShoot = Time.time;
			Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity, _bulletAnchor);
		}

		public bool CanShoot()
		{
			return Time.time - _lastShoot > timeBetweenShoots;
		}
	}
}