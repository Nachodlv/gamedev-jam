using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enemy
{
	public class EnemyWeapon : MonoBehaviour
	{
		[SerializeField] private Bullet bulletPrefab;
		[SerializeField] private float timeBetweenShoots;
		[SerializeField] private Transform shootingPoint;

		private float _lastShoot;
		private Transform _bulletAnchor;

		private void Start()
		{
			_bulletAnchor = new GameObject("Bullet anchor").transform;
		}

		public void Shoot(bool isRight)
		{
			_lastShoot = Time.time;
			var rotation = Quaternion.AngleAxis(isRight ? 0 : 180, Vector3.forward);
			Instantiate(bulletPrefab, shootingPoint.position, rotation, _bulletAnchor);
		}

		public bool CanShoot()
		{
			return Time.time - _lastShoot > timeBetweenShoots;
		}

		private void OnDestroy()
		{
			if(_bulletAnchor != null) Destroy(_bulletAnchor.gameObject);
		}
	}
}