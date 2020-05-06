using UnityEngine;

namespace Enemy.Ai.States
{
	public class AttackState : MoverState
	{
		private static readonly int Shoot = Animator.StringToHash("shoot");

		private EnemyWeapon _enemyWeapon;
		private Animator _animator;

		public AttackState(EnemyWeapon enemyWeapon, Animator animator, Mover mover, Transform player) : base(mover,
			animator, player)
		{
			_enemyWeapon = enemyWeapon;
			_animator = animator;
		}

		public override void Tick()
		{
			LookAtTarget();
			if (!_enemyWeapon.CanShoot()) return;
			_enemyWeapon.Shoot(Mover.FacingRight);
			_animator.SetTrigger(Shoot);
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