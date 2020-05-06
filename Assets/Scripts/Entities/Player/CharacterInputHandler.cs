﻿using DefaultNamespace;
 using Entities.Player;
 using Input;
using Player.Attack;
using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(CharacterController), typeof(WallJumper), typeof(PlayerAttacker))]
	public class CharacterInputHandler : MonoBehaviour
	{
		[SerializeField] private APlayer aPlayer;
	
		private CharacterController _characterController;
		private WallJumper _wallJumper;
		private PlayerAttacker _playerAttacker;
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
			_playerAttacker = GetComponent<PlayerAttacker>();
			_controller.Player.Jump.performed += ctx => Jump();
			_controller.Player.Crouch.performed += ctx => Crouch();
			_controller.Player.Fire.performed += ctx => Attack();

			_wallJumper.OnTouchingWall += (grabbing, right) => WallGrabbed(grabbing);
		}

		private void Update()
		{
			_movement = _controller.Player.Move.ReadValue<float>() * aPlayer.Stats.Speed;
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

		private void Attack()
		{
			if(!_isGrabbingWall) _playerAttacker.Attack();
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
}
