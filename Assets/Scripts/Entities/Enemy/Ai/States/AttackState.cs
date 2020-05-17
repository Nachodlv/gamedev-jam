using UnityEngine;

namespace Entities.Enemy.Ai.States
{
	public class AttackState : MoverState
	{
		private static readonly int Shoot = Animator.StringToHash("shoot");

		private EnemyWeapon _enemyWeapon;
		private Animator _animator;
		private bool _hasAnimator;

		public AttackState(EnemyWeapon enemyWeapon, Animator animator, Mover mover, Transform player) : base(mover,
			animator.transform, player)
		{
			_enemyWeapon = enemyWeapon;
			_animator = animator;
			_hasAnimator = true;
		}
		
		public AttackState(EnemyWeapon enemyWeapon, Transform self, Mover mover, Transform player) : base(mover, self, player)
		{
			_enemyWeapon = enemyWeapon;
			_hasAnimator = false;
		}

		public override void Tick()
		{
			LookAtTarget();
			if (!_enemyWeapon.CanShoot()) return;
			_enemyWeapon.Shoot(Mover.FacingRight);
			if(_hasAnimator) _animator.SetTrigger(Shoot);
		}

		public override void FixedTick()
		{
		}

		public override void OnEnter()
		{
		}

		public override void OnExit()
		{
		}
	}
}