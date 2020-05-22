using UnityEngine;
using Utils;

namespace Entities.Enemy
{
	public class EnemyWeapon : MonoBehaviour, IPausable
	{
		[SerializeField] private float timeBetweenShoots;
		[SerializeField] private Transform shootingPoint;
		[SerializeField] private Pool.PoolType bulletType;
		
		private float _lastShoot;
		private float _pausedTime;

		public void Shoot(bool isRight)
		{
			_lastShoot = Time.time;
			var bullet = GlobalPooler.Instance.GetBullet(bulletType).transform;
			bullet.position = shootingPoint.position;
			bullet.rotation = Quaternion.AngleAxis(isRight ? 0 : 180, Vector3.forward);
		}

		public bool CanShoot()
		{
			return Time.time - _lastShoot > timeBetweenShoots;
		}

		public void Pause()
		{
			_pausedTime = Time.time;
		}

		public void UnPause()
		{
			_lastShoot += Time.time - _pausedTime;
		}
	}
}