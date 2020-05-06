using System;
using System.Collections;
using DefaultNamespace;
using Enemy.Ai;
using UnityEngine;

namespace Enemy
{
	[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
	public class Bullet: MonoBehaviour
	{
		[SerializeField] private float speed;
		[SerializeField] private float damage;
		[SerializeField] private float timeToLive = 4f;

		private SpriteRenderer _spriteRenderer;
		private Rigidbody2D _rigidBody2D;
		private Mover _mover;
		private Func<IEnumerator> _destroyOnTimeOut;
		private WaitForSeconds _timeToLive;
		private Coroutine _destroyCoroutine;
		
		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_rigidBody2D = GetComponent<Rigidbody2D>();
			
			_timeToLive = new WaitForSeconds(timeToLive);
			_destroyOnTimeOut = DestroyOnTimeOut;
			_destroyCoroutine = StartCoroutine(_destroyOnTimeOut());
			
			_mover = new Mover(_spriteRenderer, _rigidBody2D, speed);
		}

		private void FixedUpdate()
		{
			_mover.Move(transform.right);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			var damageReceiver = other.collider.GetComponent<DamageReceiver>();
			if (damageReceiver != null)
			{
				damageReceiver.ReceiveDamage(damage, transform.position);
			}
			DestroyBullet();
		}

		private IEnumerator DestroyOnTimeOut()
		{
			yield return _timeToLive;
			DestroyBullet();
		}

		private void DestroyBullet()
		{
			StopCoroutine(_destroyCoroutine);
			Destroy(gameObject);
		}
	}
}