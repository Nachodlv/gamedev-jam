using Entities.Enemy.Enemies;
using UnityEngine;

namespace Entities.Enemy.Ai.States
{
	public class IdleState: IState
	{
		private static readonly int IdleBool = Animator.StringToHash("idle");

		private readonly float _leftPosition;
		private readonly float _rightPosition;
		private bool _goingRight;
		private readonly Animator _animator;
		private readonly Rigidbody2D _rigidBody2D;
		private Vector2 _velocity;
		private readonly Mover _mover;
		private static readonly int Speed = Animator.StringToHash("speed");
		private bool _move;

		public IdleState(Transform leftPosition, Transform rightPosition, EnemyAi enemyAi, Mover mover)
		{
			_leftPosition = leftPosition.position.x;
			_rightPosition = rightPosition.position.x;
			_animator = enemyAi.Animator;
			_rigidBody2D = enemyAi.RigidBody;
			_mover = mover;
			_move = true;
		}

		public IdleState(EnemyAi enemyAi)
		{
			_animator = enemyAi.Animator;
			_rigidBody2D = enemyAi.RigidBody;
			_move = false;
		}

		public void Tick()
		{
			if (!_move) return;
			if (_goingRight)
			{
				if (_rightPosition < _rigidBody2D.position.x) _goingRight = false;
			}
			else
			{
				if (_leftPosition > _rigidBody2D.position.x) _goingRight = true;
			}
			SetAnimatorVelocity();
		}
		
		public void FixedTick()
		{
			if (!_move) return;

			_mover.Move(_goingRight? new Vector2(1, 0) : new Vector2(-1, 0));
		}

		public void OnEnter()
		{
			_animator.SetBool(IdleBool, true);
		}

		public void OnExit()
		{
			_rigidBody2D.velocity = Vector2.zero;
			if(_move) SetAnimatorVelocity();
			_animator.SetBool(IdleBool, false);
		}

		private void SetAnimatorVelocity()
		{
			_animator.SetFloat(Speed, Mathf.Abs(_rigidBody2D.velocity.magnitude));
		}
	}
}