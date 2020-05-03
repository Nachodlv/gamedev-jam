using DefaultNamespace;
using Input;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(WallJumper))]
public class CharacterInputHandler : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 1f;
	
	private CharacterController _characterController;
	private WallJumper _wallJumper;
	private float _movement;
	private bool _jump;
	private bool _crouch;
	private InputActionController _controller;
	private bool _isGrabbingWall;

	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
		_wallJumper = GetComponent<WallJumper>();
		_controller = new InputActionController();
		_controller.Player.Jump.performed += ctx => Jump();
		_controller.Player.Crouch.performed += ctx => Crouch();
		_wallJumper.OnTouchingWall += (grabbing, right) => WallGrabbed(grabbing);
	}

	private void Update()
	{
		_movement = _controller.Player.Move.ReadValue<float>() * moveSpeed;
	}

	private void FixedUpdate()
	{
		if (_jump)
		{
			if(_wallJumper.CanWallJump()) _wallJumper.Jump();
			else _characterController.Jump();
			_jump = false;
		}
		_characterController.Move(_movement, _crouch, !_isGrabbingWall);
		_movement = 0;
		_crouch = false;
	}

	private void Jump()
	{
		_jump = true;
	}

	private void Crouch()
	{
		_crouch = true;
	}
	
	public void OnEnable()
	{
		_controller.Enable();
	}

	public void OnDisable()
	{
		_controller.Disable();
	}

	private void WallGrabbed(bool isGrabbing)
	{
		_isGrabbingWall = isGrabbing;
	}

}
