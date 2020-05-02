﻿using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
   	[SerializeField] private float jumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool airControl;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask whatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform groundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform ceilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D crouchDisableCollider;				// A collider that will be disabled when crouching
	[SerializeField] private int maxJumps = 1;

	public event Action OnJumpEvent;
	public event Action OnLandEvent;
	public event Action<bool> OnCrouchEvent;
	public bool Grounded { get; private set; }

	private const float GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private const float CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up

	private Rigidbody2D _myRigidBody2D;
	private SpriteRenderer _spriteRenderer;
	private bool _facingRight = true;  // For determining which way the player is currently facing.
	private Vector3 _velocity = Vector3.zero;
	private bool _mWasCrouching;
	private int _currentJumps;
	private Collider2D[] _colliders;
	
	private void Awake()
	{
		_myRigidBody2D = GetComponent<Rigidbody2D>();
		_colliders = new Collider2D[5];
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = Grounded;
		Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		var size = Physics2D.OverlapCircleNonAlloc(groundCheck.position, GroundedRadius, _colliders, whatIsGround);
		for (var i = 0; i < size; i++)
		{
			if (_colliders[i].gameObject == gameObject) continue;
			Grounded = true;
			if (wasGrounded) continue;
			OnLandEvent?.Invoke();
			_currentJumps = 0;
		}
	}


	public void Move(float move, bool crouch)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(ceilingCheck.position, CeilingRadius, whatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (Grounded || airControl)
		{

			// If crouching
			if (crouch)
			{
				if (!_mWasCrouching)
				{
					_mWasCrouching = true;
					OnCrouchEvent?.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= crouchSpeed;

				// Disable one of the colliders when crouching
				if (crouchDisableCollider != null)
					crouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (crouchDisableCollider != null)
					crouchDisableCollider.enabled = true;

				if (_mWasCrouching)
				{
					_mWasCrouching = false;
					OnCrouchEvent?.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, _myRigidBody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			_myRigidBody2D.velocity = Vector3.SmoothDamp(_myRigidBody2D.velocity, targetVelocity, ref _velocity, movementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !_facingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && _facingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		
	}

	public void Jump(bool ignoreMaximumJumps = false, float angle = 0)
	{
		if (!ignoreMaximumJumps && _currentJumps >= maxJumps) return;
		
		Grounded = false;
		var velocity = _myRigidBody2D.velocity;
		velocity.y = velocity.y < 0 ? 0 : velocity.y;
		_myRigidBody2D.velocity = velocity;
		_myRigidBody2D.AddForce(new Vector2(0f, jumpForce));
		_currentJumps ++;
		OnJumpEvent?.Invoke();
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		_facingRight = !_facingRight;

		// Multiply the player's x local scale by -1.
		// Vector3 theScale = transform.localScale;
		// theScale.x *= -1;
		// transform.localScale = theScale;
		_spriteRenderer.flipX = !_facingRight;
	}
}
