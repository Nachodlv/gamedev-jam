using UnityEngine;

namespace Entities.Enemy.Ai
{
	public class Mover
	{
		private readonly Rigidbody2D _rigidBody2D;
		private readonly SpriteRenderer _spriteRenderer;
		private readonly float _smoothing;
		private readonly float _speed;
		private Vector2 _velocity;
		public bool FacingRight { get; private set; }

		public Mover(SpriteRenderer spriteRenderer, Rigidbody2D rigidBody2D, float speed, float smoothing = 0.1f)
		{
			_rigidBody2D = rigidBody2D;
			_speed = speed;
			_smoothing = smoothing;
			_spriteRenderer = spriteRenderer;
		}

		public void Move(Vector2 direction)
		{
			Flip(direction);
			_rigidBody2D.velocity = 
				Vector2.SmoothDamp(_rigidBody2D.velocity, direction * _speed, ref _velocity, _smoothing);
		}

		public void Flip(Vector2 direction)
		{
			if (direction.x > 0 && !FacingRight)
			{
				FlipTransform();
				FacingRight = true;
			} else if (direction.x < 0 && FacingRight)
			{
				FlipTransform();
				FacingRight = false;
			}
		}

		private void FlipTransform()
		{
			var transform = _spriteRenderer.transform;
			var theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}