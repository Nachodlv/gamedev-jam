using System;
using System.Collections;
using Entities.Enemy.Ai;
using UnityEngine;
using Utils;

namespace Entities.Enemy
{
	[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
	public class Bullet: Pooleable, IPausable
	{
		[SerializeField] private float speed;
		[SerializeField] private float damage;
		[SerializeField] private float timeToLive = 4f;

		public float Damage
		{
			get => damage;
			set => damage = value;
		}
		
		private SpriteRenderer _spriteRenderer;
		private Rigidbody2D _rigidBody2D;
		private Mover _mover;
		private Func<IEnumerator> _destroyOnTimeOut;
		private WaitForSeconds _timeToLive;
		private Coroutine _destroyCoroutine;
		private bool _paused;
		
		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_rigidBody2D = GetComponent<Rigidbody2D>();
			
			_timeToLive = new WaitForSeconds(timeToLive);
			_destroyOnTimeOut = DestroyOnTimeOut;
			_destroyCoroutine = StartCoroutine(_destroyOnTimeOut());
			
			_mover = new Mover(_spriteRenderer, _rigidBody2D, speed);
			
			//TODO on activate change to bullet layer, reset damage
		}

		private void FixedUpdate()
		{
			if(!_paused) _mover.Move(transform.right);
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
			var timePassed = 0f;
			while (timePassed < timeToLive)
			{
				if(!_paused) timePassed += Time.deltaTime;
				yield return null;
			}
			DestroyBullet();
		}

		private void DestroyBullet()
		{
			StopCoroutine(_destroyCoroutine);
			Deactivate();
		}

		public void Pause()
		{
			_paused = true;
			_rigidBody2D.velocity = Vector2.zero;
		}

		public void UnPause()
		{
			_paused = false;
		}
	}
}