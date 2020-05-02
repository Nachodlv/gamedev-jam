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

		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			characterController.OnJumpEvent += Jump;
			characterController.OnLandEvent += Land;
		}

		private void Jump()
		{
			_animator.SetTrigger(JumpTrigger);
		}

		private void Land()
		{
			_animator.SetTrigger(GroundTrigger);
		}
		
	}
}