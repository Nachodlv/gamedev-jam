using System;
using UnityEngine;

namespace Platforms
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class MovablePlatform : MonoBehaviour
	{
		[SerializeField] private Transform[] transforms;
		[SerializeField] private float speed;
		[SerializeField] private float movementSmoothing = 0.5f;

		private Vector2[] _positions;
		private int _currentPosition;
		private Rigidbody2D _rigidBody;
		private Vector3 _velocity;
		
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
			var position = _rigidBody.position;
			var targetVelocity = NextPosition - position;
			targetVelocity = targetVelocity.normalized * speed;
			_rigidBody.velocity = Vector3.SmoothDamp(_rigidBody.velocity, targetVelocity, ref _velocity, movementSmoothing);

			if (Vector3.Distance(position, NextPosition) < 0.01f)
			{
				_currentPosition = (_currentPosition + 1) % _positions.Length;
			}
		}
	}
}