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
        [SerializeField, Tooltip("When the enemy health goes below this percentage the short range attack is triggered"), Range(0, 1)] 
        private float laserHealthPercentage;
        [SerializeField] private EnemyWeapon shortRangeWeapon;

        private float _initialHealth;
        
        protected override void SetUpStates()
        {
            var idleState = new IdleState(this);
            var largeAttackState = new AttackState(enemyWeapon, Animator, Mover, Player);
            var prepareShortAttack = new PlayAnimationState(Animator, Player, Mover, "prepareShortAttack", 0.5f);
            var shortRangeState = new MultipleStates(new List<IState>
                {new AttackState(shortRangeWeapon, Animator, Mover, Player), largeAttackState});
            var idleShortRangeState = new IdleState(this);
            var dieAnimation = new PlayAnimationState(Animator, Player, Mover, "die", 0.67f);
            var destroySelf = new DestroySelfState(gameObject);

            StateMachine.AddTransition(idleState, largeAttackState, PlayerInsideRange);
            StateMachine.AddTransition(largeAttackState, idleState, () => !PlayerInsideRange());
            StateMachine.AddTransition(largeAttackState, prepareShortAttack, HealthBelowThreshold);
            StateMachine.AddTransition(prepareShortAttack, idleShortRangeState, FinishPlayingAnimation(prepareShortAttack));
            StateMachine.AddTransition(idleShortRangeState, shortRangeState, PlayerInsideRange);
            StateMachine.AddTransition(shortRangeState, idleShortRangeState, () => !PlayerInsideRange());

            StateMachine.AddAnyTransition(dieAnimation, EnemyDie);
            StateMachine.AddTransition(dieAnimation, destroySelf, FinishPlayingAnimation(dieAnimation));
            
            StateMachine.SetState(idleState);

            _initialHealth = Stats.Health;
            bool HealthBelowThreshold() => Stats.Health <= _initialHealth * laserHealthPercentage;
        }
    }
}