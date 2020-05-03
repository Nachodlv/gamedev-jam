using System;
using Enemy.Ai.States;
using Player;
using UnityEngine;
using Utils;

namespace Enemy.Ai
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class CommonEnemy : MonoBehaviour
	{
		[SerializeField] private Stats stats;
		[SerializeField] private Transform leftPosition;
		[SerializeField] private Transform rightPosition;
		[SerializeField] private Animator animator;
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private float visionRange = 5f;
		[SerializeField] private EnemyWeapon enemyWeapon;

		public Stats Stats => stats;
		public Animator Animator => animator;
		public Rigidbody2D RigidBody { get; private set; }

		private StateMachine _stateMachine;
		private DistanceDetector _distanceDetector;
		private int _raycastLayer;

		private void Awake()
		{
			_raycastLayer = ~ LayerMask.GetMask($"Enemy");
			RigidBody = GetComponent<Rigidbody2D>();
			var player = FindObjectOfType<APlayer>().transform;
			_distanceDetector = gameObject.AddComponent<DistanceDetector>();
			_distanceDetector.DetectionDistance = visionRange;
			_distanceDetector.targetTag = "Player";

			_stateMachine = new StateMachine();
			var enemyMover = new Mover(spriteRenderer, RigidBody, stats.Speed);
			var idleState = new IdleState(leftPosition, rightPosition, this, enemyMover);
			var startAttackingState =
				new PlayAnimationState(animator, player, enemyMover, "startAttacking", "Prepare to attack");
			var attackState = new AttackState(enemyWeapon, animator);
			var stopAttackingState =
				new PlayAnimationState(animator, player, enemyMover, "stopAttacking", "Prepare to attack");

			_stateMachine.AddTransition(idleState, startAttackingState, PlayerInsideRange);
			_stateMachine.AddTransition(startAttackingState, attackState, FinishPlayingAnimation(startAttackingState));
			_stateMachine.AddTransition(attackState, stopAttackingState, PlayerOutsideRange);
			_stateMachine.AddTransition(stopAttackingState, idleState, FinishPlayingAnimation(stopAttackingState));

			_stateMachine.SetState(idleState);

			bool PlayerOutsideRange() => !PlayerInsideRange();
			Func<bool> FinishPlayingAnimation(PlayAnimationState state) => () => state.Finished;
		}

		private bool PlayerInsideRange()
		{
			var colliders = _distanceDetector.GetColliders();
			if (colliders.Count == 0) return false;
			var position = transform.position;
			Debug.DrawLine(position, colliders[0].position);
			var hit = Physics2D.Linecast(position, colliders[0].position, _raycastLayer);
			var hitTransform = hit.transform;
			if (hitTransform == null) return true;
			return hitTransform.gameObject == colliders[0].gameObject;
		}

		private void Update()
		{
			_stateMachine.Tick();
		}

		private void FixedUpdate()
		{
			_stateMachine.FixedTick();
		}
	}
}