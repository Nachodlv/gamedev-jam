using UnityEngine;

namespace Enemy.Ai
{
	public class EnemyMover
	{
		private readonly Rigidbody2D _rigidBody2D;
		private readonly float _smoothing;
		private readonly float _speed;
		private Vector2 _velocity;

		public EnemyMover(Rigidbody2D rigidBody2D, float speed, float smoothing = 0.1f)
		{
			_rigidBody2D = rigidBody2D;
			_speed = speed;
			_smoothing = smoothing;
		}

		public void Move(Vector2 direction)
		{
			_rigidBody2D.velocity = 
				Vector2.SmoothDamp(_rigidBody2D.velocity, direction * _speed, ref _velocity, _smoothing);
		}
	}
}