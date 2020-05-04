using System;
using Enemy.Ai.States;
using Player;
using UnityEngine;
using Utils;

namespace Enemy.Ai
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class CommonEnemy : Enemy
	{
		[SerializeField] private Transform leftPosition;
		[SerializeField] private Transform rightPosition;
		

		protected override void SetUpStates()
		{
			var enemyMover = new Mover(spriteRenderer, RigidBody, Stats.Speed);
			var idleState = new IdleState(leftPosition, rightPosition, this, enemyMover);
			var startAttackingState =
				new PlayAnimationState(Animator, Player, enemyMover, "startAttacking", "Prepare to attack");
			var attackState = new AttackState(enemyWeapon, Animator);
			var stopAttackingState =
				new PlayAnimationState(Animator, Player, enemyMover, "stopAttacking", "Prepare to attack");

			StateMachine.AddTransition(idleState, startAttackingState, PlayerInsideRange);
			StateMachine.AddTransition(startAttackingState, attackState, FinishPlayingAnimation(startAttackingState));
			StateMachine.AddTransition(attackState, stopAttackingState, PlayerOutsideRange);
			StateMachine.AddTransition(stopAttackingState, idleState, FinishPlayingAnimation(stopAttackingState));

			StateMachine.SetState(idleState);

			bool PlayerOutsideRange() => !PlayerInsideRange();
			Func<bool> FinishPlayingAnimation(PlayAnimationState state) => () => state.Finished;
		}
		
	}
}