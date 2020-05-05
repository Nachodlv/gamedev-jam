using UnityEngine;

namespace Enemy.Ai.States
{
	public class AttackState: IState
	{
		private static readonly int Shoot = Animator.StringToHash("shoot");

		private EnemyWeapon _enemyWeapon;
		private Animator _animator;

		public AttackState(EnemyWeapon enemyWeapon, Animator animator)
		{
			_enemyWeapon = enemyWeapon;
			_animator = animator;
		}

		public void Tick()
		{
			if (!_enemyWeapon.CanShoot()) return;
			_enemyWeapon.Shoot();
			_animator.SetTrigger(Shoot);
		}

		public void FixedTick()
		{
		}

		public void OnEnter()
		{
		}

		public void OnExit()
		{
		}
	}
}