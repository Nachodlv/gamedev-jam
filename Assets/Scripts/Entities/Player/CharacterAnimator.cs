using System;
using DefaultNamespace;
using Entities.Player;
using Player.Attack;
using UnityEngine;

namespace Player
{
	[RequireComponent(typeof(Animator))]
	public class CharacterAnimator : MonoBehaviour
	{
		[SerializeField] private CharacterController characterController;
		[SerializeField] private WallJumper wallJumper;
		[SerializeField] private PlayerAttacker playerAttacker;
		[SerializeField] private DashAbility dashAbility;
		[SerializeField] private APlayer player;
		
		public event Action OnAttackAnimation;
		
		private static readonly int JumpTrigger = Animator.StringToHash("jump");
		private static readonly int GroundTrigger = Animator.StringToHash("ground");
		private static readonly int WallBool = Animator.StringToHash("grabWall");
		private static readonly int Speed = Animator.StringToHash("speed");
		private static readonly int AttackTrigger = Animator.StringToHash("attack");
		private static readonly int DashTrigger = Animator.StringToHash("dash");
		private static readonly int DieTrigger = Animator.StringToHash("die");

		private Animator _animator;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			characterController.OnJumpEvent += Jump;
			characterController.OnLandEvent += Land;
			wallJumper.OnTouchingWall += GrabWall;
			playerAttacker.OnStartAttack += StartAttack;
			dashAbility.OnDash += Dash;
			player.OnDie += Die;
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

		private void StartAttack()
		{
			_animator.SetTrigger(AttackTrigger);
		}

		private void MakeAttack()
		{
			OnAttackAnimation?.Invoke();
		}

		private void Dash()
		{
			_animator.SetTrigger(DashTrigger);
		}

		private void MakeDash()
		{
			dashAbility.MakeDash();
		}

		private void Die()
		{
			_animator.SetTrigger(DieTrigger);
		}
	}
}