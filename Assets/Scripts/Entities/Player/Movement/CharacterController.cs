using System;
using UnityEngine;

namespace Entities.Player.Movement
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class CharacterController : MonoBehaviour
	{
		[SerializeField] private float jumpForce = 400f;							// Amount of force added when the player jumps.
		[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;	// How much to smooth out the movement
		[SerializeField] private LayerMask whatIsGround;							// A mask determining what is ground to the character
		[SerializeField] private Transform groundCheck;							// A position marking where to check if the player is grounded.
		[SerializeField] private int maxJumps = 1;
		[SerializeField] private float maxVelocity = 5f;
		[SerializeField] private float timeJumping = 1f;
		[SerializeField] private float airControl = 100f;
	
		public event Action OnJumpEvent;
		public event Action OnLandEvent;
		public event Action<bool> OnCrouchEvent;
		public event Action OnFlip;
		public bool Grounded { get; private set; }
		public Vector3 Velocity => _myRigidBody2D.velocity;
		public bool FacingRight { get; private set; } = true;

		public bool AirControl { get; set; } = true;

		private const float GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded

		private Rigidbody2D _myRigidBody2D;
		private Vector3 _velocity = Vector3.zero;
		private bool _wasCrouching;
		private int _currentJumps;
		private Collider2D[] _colliders;
		private Vector2 _jumpDirection;
		private bool _jumping;
		private float _jumpTime;

		private void Awake()
		{
			_myRigidBody2D = GetComponent<Rigidbody2D>();
			_colliders = new Collider2D[5];
		}

		private void FixedUpdate()
		{
			if (_jumping)
			{
				Jump();
				return;
			}			
			var wasGrounded = Grounded;

			var size = Physics2D.OverlapCircleNonAlloc(groundCheck.position, GroundedRadius, _colliders, whatIsGround);
			for (var i = 0; i < size; i++)
			{
				if (_colliders[i].gameObject == gameObject) continue;
			
				Grounded = true;
				_currentJumps = 0;
				if (!wasGrounded)
				{
					OnLandEvent?.Invoke();
				}
				return;
			}

			Grounded = false;
		}
	
		public void Move(float move, bool crouch, bool canFlip )
		{
		
			// Move the character by finding the target velocity
			var velocity = _myRigidBody2D.velocity;
			// if (Grounded)
			// {
				Vector3 targetVelocity = new Vector2(move * 10f, velocity.y);
				var newVelocity = Vector3.SmoothDamp(velocity, targetVelocity, ref _velocity, 
					movementSmoothing, maxVelocity);
				_myRigidBody2D.velocity = newVelocity;
			// }
			// else if(AirControl && Mathf.Abs(_myRigidBody2D.velocity.x) < maxVelocity)
			// {
			// 	Debug.Log("In The Air");
			// 	Vector3 targetVelocity = new Vector2(move * airControl, 0);
			// 	_myRigidBody2D.AddForce(targetVelocity);
			// }
		
			if (move > 0 && !FacingRight && canFlip)
			{
				Flip();
			}
			else if (move < 0 && FacingRight && canFlip)
			{
				Flip();
			}
		
		}

		public void StartJumping()
		{
			StartJumpWithOptions(false, 0, jumpForce);
		}

		public void StopJumping()
		{
			_jumping = false;
		}

		public void StartJumpWithOptions(bool ignoreMaximumJumps, float angle, float force)
		{
			if ((!ignoreMaximumJumps && _currentJumps >= maxJumps) || _jumping) return;
			_jumping = true;
			Grounded = false;
			_jumpTime = Time.time;
			_currentJumps ++;

			var velocity = _myRigidBody2D.velocity;
			velocity.y = velocity.y < 0 ? 0 : velocity.y;
			_myRigidBody2D.velocity = velocity;
			_jumpDirection = new Vector2(0f, force);
			_jumpDirection = Quaternion.Euler(0, 0, angle) * _jumpDirection;
			_myRigidBody2D.AddForce(_jumpDirection * 5);
			OnJumpEvent?.Invoke();
		}

		private void Jump()
		{
			if(Time.time - _jumpTime > timeJumping) StopJumping();

			_myRigidBody2D.AddForce(_jumpDirection * ((timeJumping - (Time.time - _jumpTime)) / timeJumping));
		}

		public void Flip()
		{
			// Switch the way the player is labelled as facing.
			FacingRight = !FacingRight;

			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			// spriteRenderer.flipX = !_facingRight;
			OnFlip?.Invoke();
		}
	}
}
