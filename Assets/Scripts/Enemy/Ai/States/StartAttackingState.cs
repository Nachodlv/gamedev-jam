using System;
using UnityEngine;

namespace Enemy.Ai.States
{
	public class StartAttackingState: IState
	{
		private static readonly int StartAttacking = Animator.StringToHash("startAttacking");

		public bool Finished { get; private set; }
		
		private readonly Animator _animator;
		private readonly Transform _player;
		private readonly EnemyMover _enemyMover;
		private float _remainingTime;

		public StartAttackingState(Animator animator, Transform player, EnemyMover enemyMover)
		{
			_animator = animator;
			_enemyMover = enemyMover;
			_player = player;
		}

		public void Tick()
		{
			_remainingTime -= Time.deltaTime;
			if (_remainingTime <= 0) Finished = true;
		}

		public void FixedTick()
		{
		}

		public void OnEnter()
		{
			LookAtTarget();
			_animator.SetTrigger(StartAttacking);
			var clips = _animator.GetCurrentAnimatorClipInfo(0);
			foreach (var animatorClipInfo in clips)
			{
				if (animatorClipInfo.clip.name == "PrepareToAttack")
				{
					_remainingTime = animatorClipInfo.clip.length;
				}
			}
		}

		public void OnExit()
		{
			_remainingTime = 0;
			Finished = false;
		}

		private void LookAtTarget()
		{
			_enemyMover.Flip(_player.position.x < _animator.transform.position.x ? new Vector2(-1, 0) : new Vector2(1, 0));
	
		}
	}
}