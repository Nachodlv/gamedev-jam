using System;
using System.Collections.Generic;
using Entities;
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
		
		private Vector2 NextPosition => _positions[_currentPosition];

		private void Awake()
		{
			_rigidBody = GetComponent<Rigidbody2D>();
			_positions = new Vector2[transforms.Length];
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
			if (Vector3.Distance(position, NextPosition) < 0.1f)
			{
				_currentPosition = (_currentPosition + 1) % _positions.Length;
			}
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