using System;
using UnityEngine;
using Utils;

namespace Entities.Player.Movement
{
	[RequireComponent(typeof(CharacterController), typeof(Rigidbody2D))]
	public class WallJumper : MonoBehaviour
	{
		[SerializeField] private Transform rightCheck;
		[SerializeField] private Transform leftCheck;
		[SerializeField] private LayerMask whatIsWall;
		[SerializeField] private float maximumTimeGrabbingWall = 1f;
		[SerializeField] private float wallJump = 1000f;
		[SerializeField] private float timeNotMoving = 1f;

		public delegate void TouchingWall(bool isTouching, bool isRight);
		public event TouchingWall OnTouchingWall;

		private const float TriggerRadius = 0.2f;

		private CharacterController _characterController;
		private bool _touchingRightWall;
		private bool _touchingLeftWall;
		private Rigidbody2D _rigidBody2D;
		private Collider2D[] _colliders;
		private float _timeGrabbingWall;
		private float _previousCollider;
		private bool _rightTrigger;
		private bool _leftTrigger;
		private WaitSeconds _waitSeconds;

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			_rigidBody2D = GetComponent<Rigidbody2D>();
			_colliders = new Collider2D[5];
			_waitSeconds = new WaitSeconds(this, RegainMovement, timeNotMoving);
			OnTouchingWall += WallTouched;
			_characterController.OnLandEvent += OnLand;
		}

		private void Update()
		{
			if (_touchingLeftWall || _touchingRightWall) _timeGrabbingWall += Time.deltaTime;
			if (_timeGrabbingWall > maximumTimeGrabbingWall) WallTouched(false, false);
			
			if (!_touchingRightWall && _rightTrigger)
			{
				OnTouchingWall?.Invoke(true, _characterController.FacingRight);
				return;
			}

			if (!_touchingLeftWall && _leftTrigger)
			{
				OnTouchingWall?.Invoke(true,  !_characterController.FacingRight);
				return;
			}

			if (!_rightTrigger && !_leftTrigger && (_touchingLeftWall || _touchingRightWall))
			{
				OnTouchingWall?.Invoke(false, false);
			}
		}

		private void FixedUpdate()
		{
			if (_touchingLeftWall || _touchingRightWall)
			{
				var velocity = _rigidBody2D.velocity;
				velocity.y = velocity.y < 0 ? 0 : velocity.y;
				_rigidBody2D.velocity = velocity;
			}

			_rightTrigger = CheckTrigger(rightCheck);
			_leftTrigger = CheckTrigger(leftCheck);
		}

		public void Jump()
		{
			Debug.Log("Wall jump!");
			_timeGrabbingWall = 0;
			_characterController.JumpWithOptions(true, _touchingRightWall ? 45 : -45, wallJump);
			_characterController.AirControl = false;
			_waitSeconds.Wait();
		}

		public bool CanWallJump()
		{
			if ((!_touchingLeftWall && !_touchingRightWall) || _timeGrabbingWall > maximumTimeGrabbingWall)
				return false;
			var y = transform.position.x;

			if (Math.Abs(y - _previousCollider) < 0.5f) return false;
			_previousCollider = y;
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
			_previousCollider = float.MaxValue;
			OnTouchingWall?.Invoke(false, false);
		}

		private void RegainMovement()
		{
			_characterController.AirControl = true;
		}
	}
}