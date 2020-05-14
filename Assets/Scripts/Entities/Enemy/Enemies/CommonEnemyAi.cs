﻿using System;
using Enemy.Ai.States;
 using Entities.Enemy.Enemies;
 using Player;
using UnityEngine;
using Utils;

namespace Enemy.Ai
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class CommonEnemyAi : EnemyAi
	{
		[SerializeField] private Transform leftPosition;
		[SerializeField] private Transform rightPosition;
		[SerializeField] private float prepareToAttackAnimationLength;
		[SerializeField] private float dieAnimationLength;

		private bool deadTriggered;

		protected override void SetUpStates()
		{
			var enemyMover = new Mover(spriteRenderer, RigidBody, Stats.Speed);
			var idleState = new IdleState(leftPosition, rightPosition, this, enemyMover);
			var startAttackingState =
				new PlayAnimationState(Animator, Player, enemyMover, "startAttacking", prepareToAttackAnimationLength);
			var attackState = new AttackState(enemyWeapon, Animator, enemyMover, Player);
			var stopAttackingState =
				new PlayAnimationState(Animator, Player, enemyMover, "stopAttacking", prepareToAttackAnimationLength);
			var dieState = new PlayAnimationState(Animator, Player, enemyMover, "die", dieAnimationLength);
			var destroySelf = new DestroySelfState(gameObject);
			
			StateMachine.AddTransition(idleState, startAttackingState, PlayerInsideRange);
			StateMachine.AddTransition(startAttackingState, attackState, FinishPlayingAnimation(startAttackingState));
			StateMachine.AddTransition(attackState, stopAttackingState, PlayerOutsideRange);
			StateMachine.AddTransition(stopAttackingState, idleState, FinishPlayingAnimation(stopAttackingState));
			StateMachine.AddTransition(dieState, destroySelf, FinishPlayingAnimation(dieState));

			StateMachine.AddAnyTransition(dieState, EnemyDie);

			StateMachine.SetState(idleState);

			bool PlayerOutsideRange() => !PlayerInsideRange();
			Func<bool> FinishPlayingAnimation(PlayAnimationState state) => () => state.Finished;
			
			bool EnemyDie()
			{
				if (!Dead || deadTriggered) return false;
				deadTriggered = true;
				return true;
			}
		}
		
	}
}