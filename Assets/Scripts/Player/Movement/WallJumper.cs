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
		[SerializeField] private float maximumTimeGrabbingWall = 1f;
		[SerializeField] private float wallJump = 1000f;

		public delegate void TouchingWall(bool isTouching, bool isRight);
		public event TouchingWall OnTouchingWall;

		private const float TriggerRadius = 0.1f;

		private CharacterController _characterController;
		private bool _touchingRightWall;
		private bool _touchingLeftWall;
		private Rigidbody2D _rigidBody2D;
		private Collider2D[] _colliders;
		private float _timeGrabbingWall;
		private Collider2D _previousCollider;

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			_rigidBody2D = GetComponent<Rigidbody2D>();
			_colliders = new Collider2D[5];
			OnTouchingWall += WallTouched;
			_characterController.OnLandEvent += OnLand;
			// _characterController.OnFlip += OnFlip;
		}

		private void Update()
		{
			if (_touchingLeftWall || _touchingRightWall) _timeGrabbingWall += Time.deltaTime;
			if (_timeGrabbingWall > maximumTimeGrabbingWall) WallTouched(false, false);
		}

		private void FixedUpdate()
		{
			if (_touchingLeftWall || _touchingRightWall)
			{
				var velocity = _rigidBody2D.velocity;
				velocity.y = velocity.y < 0 ? 0 : velocity.y;
				_rigidBody2D.velocity = velocity;
			}

			var rightTrigger = CheckTrigger(rightCheck);
			var leftTrigger = CheckTrigger(leftCheck);
			
			if (!_touchingRightWall && rightTrigger)
			{
				OnTouchingWall?.Invoke(true, _characterController.FacingRight);
				return;
			}

			if (!_touchingLeftWall && leftTrigger)
			{
				OnTouchingWall?.Invoke(true,  !_characterController.FacingRight);
				return;
			}

			if (!rightTrigger && !leftTrigger && (_touchingLeftWall || _touchingRightWall))
			{
				OnTouchingWall?.Invoke(false, false);
			}
		}

		public void Jump()
		{
			_characterController.JumpWithOptions(true, _touchingRightWall ? 45 : -45, wallJump);
		}

		public bool CanWallJump()
		{
			if ((!_touchingLeftWall && !_touchingRightWall) || _timeGrabbingWall > maximumTimeGrabbingWall)
				return false;
			if (_colliders[0] == _previousCollider) return false;
			_previousCollider = _colliders[0];
			return true;
		}

		private bool CheckTrigger(Transform trigger)
		{
			if (_characterController.Grounded || _timeGrabbingWall > maximumTimeGrabbingWall) return false;
			var size = Physics2D.OverlapCircleNonAlloc(trigger.position, TriggerRadius, _colliders, whatIsWall);
			return size > 0;
		}

		private void WallTouched(bool isTouching, bool isRight)
		{
			if (!isTouching)
			{
				_touchingRightWall = false;
				_touchingLeftWall = false;
				return;
			}
			
			if (isRight) _touchingRightWall = true;
			else _touchingLeftWall = true;
		}

		private void OnLand()
		{
			_timeGrabbingWall = 0;
			_previousCollider = null;
			OnTouchingWall?.Invoke(false, false);
		}

		private void OnFlip()
		{
			OnTouchingWall?.Invoke(false, false);
			_timeGrabbingWall = maximumTimeGrabbingWall;
		}
	}
}