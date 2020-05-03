using System;
using UnityEngine;

namespace DefaultNamespace
{
	[RequireComponent(typeof(Animator))]
	public class CharacterMovementAnimator : MonoBehaviour
	{
		[SerializeField] private CharacterController characterController;
		[SerializeField] private WallJumper wallJumper;

		private static readonly int JumpTrigger = Animator.StringToHash("jump");
		private static readonly int GroundTrigger = Animator.StringToHash("ground");
		private static readonly int WallBool = Animator.StringToHash("grabWall");
		private static readonly int Speed = Animator.StringToHash("speed");

		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			characterController.OnJumpEvent += Jump;
			characterController.OnLandEvent += Land;
			wallJumper.OnTouchingWall += GrabWall;
		}

		private void Update()
		{
			_animator.SetFloat(Speed, characterController.Grounded ? Mathf.Abs(characterController.Velocity.x) : 0);
		}

		private void Jump()
		{
			_animator.SetTrigger(JumpTrigger);
		}

		private void Land()
		{
			_animator.SetTrigger(GroundTrigger);
		}

		private void GrabWall(bool isGrabbed, bool isRight)
		{
			_animator.SetBool(WallBool, isGrabbed);
		}
	}
}