using System;
using UnityEngine;

namespace DefaultNamespace
{
	[RequireComponent(typeof(CharacterController), typeof(Rigidbody2D))]
	public class WallJumper : MonoBehaviour
	{
		[SerializeField] private Transform rightCheck;
		[SerializeField] private Transform leftCheck;
		[SerializeField] private LayerMask whatIsWall;
		[SerializeField] private float slideScale = 0.5f;

		public delegate void TouchingWall(bool isTouching, bool isRight);

		public TouchingWall OnTouchingWall;

		private const float TriggerRadius = 0.2f;

		private CharacterController _characterController;
		private bool _touchingRightWall;
		private bool _touchingLeftWall;
		private Rigidbody2D _rigidBody2D;
		private Collider2D[] _colliders;

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			_rigidBody2D = GetComponent<Rigidbody2D>();
			_colliders = new Collider2D[5];
		}

		private void FixedUpdate()
		{
			if (_touchingLeftWall || _touchingRightWall)
			{
				_rigidBody2D.AddForce(Vector2.down * (_rigidBody2D.gravityScale * slideScale));
			}

			if (!_touchingRightWall && CheckTrigger(rightCheck))
			{
				_touchingRightWall = true;
				OnTouchingWall?.Invoke(true, true);
				return;
			}

			if (!_touchingLeftWall && CheckTrigger(leftCheck))
			{
				_touchingLeftWall = true;
				OnTouchingWall?.Invoke(true, false);
				return;
			}
			
			OnTouchingWall?.Invoke(false, false);
			_touchingRightWall = false;
			_touchingLeftWall = false;
		}

		public void Jump()
		{
			if (CanWallJump())
			{
				_characterController.Jump(true);
			}
		}

		public bool CanWallJump()
		{
			return _touchingLeftWall || _touchingRightWall;
		}

		private bool CheckTrigger(Transform trigger)
		{
			return !_characterController.Grounded &&
			       Physics2D.OverlapCircleNonAlloc(trigger.position, TriggerRadius, _colliders, whatIsWall) > 0;
		}
	}
}