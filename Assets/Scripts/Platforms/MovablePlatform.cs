using System;
using System.Collections.Generic;
using Entities;
using Entities.Enemy;
using Entities.Enemy.Enemies;
using Entities.Player;
using UnityEngine;

namespace Platforms
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class MovablePlatform : MonoBehaviour, IPausable
	{
		[SerializeField] private Transform[] transforms;
		[SerializeField] private float speed;
		[SerializeField] private float movementSmoothing = 0.1f;

		private Vector2[] _positions;
		private int _currentPosition;
		private Rigidbody2D _rigidBody;
		private Vector2 _velocity;
		private bool _paused;
		private Vector2 _targetVelocity;
		private Rigidbody2D _player;
		private bool _hasPlayer;
		private Vector2 _previousPosition;
		
		private Vector2 NextPosition => _positions[_currentPosition];

		private void Awake()
		{
			_rigidBody = GetComponent<Rigidbody2D>();
			_positions = new Vector2[transforms.Length];
			_previousPosition = transform.position;
			for (var i = 0; i < transforms.Length; i++)
			{
				_positions[i] = transforms[i].position;
			}
		}

		private void Update()
		{
			if (_paused) return;
			var position = _rigidBody.position;
			var targetVelocity = NextPosition - position;
			targetVelocity = targetVelocity.normalized * speed;
			var velocity = Vector2.SmoothDamp(_rigidBody.velocity, targetVelocity, ref _velocity, movementSmoothing);
			_rigidBody.velocity = velocity;
			
			if (_hasPlayer) _player.position += position - _previousPosition;
			
 			if (Vector3.Distance(position, NextPosition) < speed/20)
			{
				_currentPosition = (_currentPosition + 1) % _positions.Length;
			}

            _previousPosition = position;
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (!other.collider.CompareTag("Player")) return;
			_hasPlayer = true;
			_player = other.gameObject.GetComponent<Rigidbody2D>();
		}

		private void OnCollisionExit2D(Collision2D other1)
		{
			_hasPlayer = false;
		}

		public void Pause()
		{
			_paused = true;
			_rigidBody.velocity = Vector2.zero;
		}

		public void UnPause()
		{
			_paused = false;
		}
	}
}