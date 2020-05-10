using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
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
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private float maxVelocity = 5f;
	
	public event Action OnJumpEvent;
	public event Action OnLandEvent;
	public event Action<bool> OnCrouchEvent;
	public event Action OnFlip;
	public bool Grounded { get; private set; }
	public Vector3 Velocity => _myRigidBody2D.velocity;
	public bool FacingRight { get; private set; } = true;

	private const float GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private const float CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up

	private Rigidbody2D _myRigidBody2D;
	private Vector3 _velocity = Vector3.zero;
	private bool _wasCrouching;
	private int _currentJumps;
	private bool _justJump;
	private Collider2D[] _colliders;

	private void Awake()
	{
		_myRigidBody2D = GetComponent<Rigidbody2D>();
		_colliders = new Collider2D[5];
	}

	private void FixedUpdate()
	{
		// if(Grounded) return;
		var wasGrounded = Grounded;
		if (_justJump)
		{
			_justJump = false;
			return;
		}
		
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
				if (!_wasCrouching)
				{
					_wasCrouching = true;
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

				if (_wasCrouching)
				{
					_wasCrouching = false;
					OnCrouchEvent?.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			var velocity = _myRigidBody2D.velocity;
			Vector3 targetVelocity = new Vector2(move * 10f, velocity.y);
			// And then smoothing it out and applying it to the character
			var newVelocity = Vector3.SmoothDamp(velocity, targetVelocity, ref _velocity, movementSmoothing);
			newVelocity.y = newVelocity.y > maxVelocity ? maxVelocity : newVelocity.y;
			_myRigidBody2D.velocity = newVelocity;

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !FacingRight && canFlip)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && FacingRight && canFlip)
			{
				// ... flip the player.
				Flip();
			}
		}
		
	}

	public void Jump()
	{
		JumpWithOptions(false, 0, jumpForce);
	}

	public void JumpWithOptions(bool ignoreMaximumJumps, float angle, float force)
	{
		if (!ignoreMaximumJumps && _currentJumps >= maxJumps) return;
		_justJump = true;	
		Grounded = false;
		var velocity = _myRigidBody2D.velocity;
		velocity.y = velocity.y < 0 ? 0 : velocity.y;
		_myRigidBody2D.velocity = velocity;
		var jumpDirection = new Vector2(0f, force);
		jumpDirection = Quaternion.Euler(0, 0, angle) * jumpDirection;
		_myRigidBody2D.AddForce(jumpDirection);
		_currentJumps ++;
		OnJumpEvent?.Invoke();
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
