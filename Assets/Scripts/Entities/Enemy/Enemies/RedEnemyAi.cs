using System.Collections.Generic;
using Enemy;
using Enemy.Ai;
using Enemy.Ai.States;
using Entities.Enemy.Ai.States;
using UnityEngine;

namespace Entities.Enemy.Enemies
{
    public class RedEnemyAi : EnemyAi
    {
        [SerializeField] private float closeRange;
        [SerializeField] private EnemyWeapon shortRangeWeapon;

        protected override void SetUpStates()
        {
            var idleState = new IdleState(this);
            var largeAttackState = new AttackState(enemyWeapon, Animator, Mover, Player);
            var prepareShortAttack = new PlayAnimationState(Animator, Player, Mover, "prepareShortAttack", 0.5f);
            var shortRangeState = new MultipleStates(new List<IState>
                {new AttackState(shortRangeWeapon, Animator, Mover, Player), largeAttackState});
            var unPrepareShortAttack = new PlayAnimationState(Animator, Player, Mover, "unPrepareShortAttack", 0.5f);
            var dieAnimation = new PlayAnimationState(Animator, Player, Mover, "die", 0.67f);
            var destroySelf = new DestroySelfState(gameObject);

            StateMachine.AddTransition(idleState, largeAttackState, PlayerInsideRange);
            StateMachine.AddTransition(largeAttackState, idleState, () => !PlayerInsideRange());
            StateMachine.AddTransition(largeAttackState, prepareShortAttack, PlayerInsideCloseRange);
            StateMachine.AddTransition(prepareShortAttack, shortRangeState, FinishPlayingAnimation(prepareShortAttack));
            StateMachine.AddTransition(shortRangeState, unPrepareShortAttack, () => !PlayerInsideCloseRange());
            StateMachine.AddTransition(unPrepareShortAttack, largeAttackState,
                FinishPlayingAnimation(unPrepareShortAttack));

            StateMachine.AddAnyTransition(dieAnimation, EnemyDie);
            StateMachine.AddTransition(dieAnimation, destroySelf, FinishPlayingAnimation(dieAnimation));
            
            StateMachine.SetState(idleState);
            
            bool PlayerInsideCloseRange() => Vector3.Distance(transform.position, Player.position) < closeRange;
        }
    }
}