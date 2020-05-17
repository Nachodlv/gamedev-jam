﻿using System;
using Entities.Player.Attack;
using Entities.Player.Movement;
using Input;
using UnityEngine;
using Utils;
using CharacterController = Entities.Player.Movement.CharacterController;

namespace Entities.Player
{
	[RequireComponent(
		typeof(CharacterController), 
		typeof(WallJumper), 
		typeof(PlayerAttacker))]
	public class CharacterInputHandler : MonoBehaviour
	{
		[SerializeField] private APlayer aPlayer;
		[SerializeField] private float timeForDoublePress = 0.4f;
		
		private CharacterController _characterController;
		private WallJumper _wallJumper;
		private PlayerAttacker _playerAttacker;
		private float _movement;
		private bool _jump;
		private bool _crouch;
		private InputActionController _controller;
		private bool _isGrabbingWall;
		private float _lastTimePressed;
		private AxisDetection _axisDetection;
		private bool _enabled = true;

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			_wallJumper = GetComponent<WallJumper>();
			_controller = new InputActionController();
			_playerAttacker = GetComponent<PlayerAttacker>();
			_controller.Player.Jump.performed += ctx => PlayerFunction(Jump);
			_controller.Player.Crouch.performed += ctx => PlayerFunction(Crouch);
			_controller.Player.Attack.performed += ctx => PlayerFunction(Attack);
			_controller.Player.TimeStop.performed += ctx => PlayerFunction(TimeStopAbility);
			_controller.Player.Dash.performed += ctx => PlayerFunction(Dash);
			
			_wallJumper.OnTouchingWall += (grabbing, right) => WallGrabbed(grabbing);

			aPlayer.OnDie += () => _enabled = false;
			aPlayer.OnResetLevel += () => _enabled = true;
			// _axisDetection = new AxisDetection(Move, Dash, timeForDoublePress);
		}

		private void Update()
		{
			// _axisDetection.Update(_controller.Player.Move.ReadValue<float>());
			_movement = _controller.Player.Move.ReadValue<float>() * aPlayer.Stats.Speed;
		}

		private void FixedUpdate()
		{
			if (!_enabled) return;
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

		private void PlayerFunction(Action playerFunction)
		{
			if (_enabled) playerFunction();
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

		private void TimeStopAbility()
		{
			aPlayer.TimeStopAbility.Pause();
		}

		private void Dash()
		{
			aPlayer.DashAbility.Dash();
		}

		private void Move(float axis)
		{
			_movement = axis * aPlayer.Stats.Speed;
		}
	}
}
