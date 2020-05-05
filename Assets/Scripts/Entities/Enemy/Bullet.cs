using System;
using Enemy.Ai;
using UnityEngine;

namespace Enemy
{
	[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
	public class Bullet: MonoBehaviour
	{
		[SerializeField] private float speed;
		[SerializeField] private float damage;

		private SpriteRenderer _spriteRenderer;
		private Rigidbody2D _rigidBody2D;
		private Mover _mover;
		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_rigidBody2D = GetComponent<Rigidbody2D>();
			_mover = new Mover(_spriteRenderer, _rigidBody2D, speed);
		}

		private void FixedUpdate()
		{
			_mover.Move(transform.right);
		}
	}
}