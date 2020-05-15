using System;
using Enemy;
using Enemy.Ai;
using Enemy.Ai.States;
using Entities.Player;
using UnityEngine;
using Utils;

namespace Entities.Enemy.Enemies
{
	[RequireComponent(typeof(AEnemy))]
	public abstract class EnemyAi: MonoBehaviour, IPausable
	{
		[SerializeField] private Animator animator;
		[SerializeField] protected SpriteRenderer spriteRenderer;
		[SerializeField] protected float visionRange = 5f;
		[SerializeField] protected EnemyWeapon enemyWeapon;
		[SerializeField] private LayerMask ignoredLayers;
		
		public Animator Animator => animator;
		public Rigidbody2D RigidBody { get; private set; }
		protected Mover Mover { get; private set; }
		private Stats Stats => _enemy.Stats;

		
		protected StateMachine StateMachine;
		protected Transform Player;
		
		private DistanceDetector _distanceDetector;
		private bool _paused;
		private AEnemy _enemy;
		private bool _deadTriggered;
		private bool _dead;

		private void Awake()
		{
			_enemy = GetComponent<AEnemy>();
			Mover = new Mover(spriteRenderer, RigidBody, Stats.Speed);

			_enemy.OnDie += OnDie;
			RigidBody = GetComponent<Rigidbody2D>();
			Player = FindObjectOfType<APlayer>().transform;
			_distanceDetector = gameObject.AddComponent<DistanceDetector>();
			_distanceDetector.DetectionDistance = visionRange;
			_distanceDetector.targetTag = "Player";

			StateMachine = new StateMachine();
			SetUpStates();
		}

		private void Update()
		{
			if(!_paused) StateMachine.Tick();
		}

		private void FixedUpdate()
		{
			if(!_paused) StateMachine.FixedTick();
		}
		
		protected bool PlayerInsideRange()
		{
			var colliders = _distanceDetector.GetColliders();
			if (colliders.Count == 0) return false;
			var position = transform.position;
			Debug.DrawLine(position, colliders[0].position);
			var hit = Physics2D.Linecast(position, colliders[0].position, ignoredLayers);
			var hitTransform = hit.transform;
			if (hitTransform == null) return true;
			return hitTransform.gameObject == colliders[0].gameObject;
		}
		
		protected Func<bool> FinishPlayingAnimation(PlayAnimationState state) => () => state.Finished;
		
		protected bool EnemyDie()
		{
			if (!_dead || _deadTriggered) return false;
			_deadTriggered = true;
			return true;
		}
		
		protected abstract void SetUpStates();
		
		public void Pause()
		{
			_paused = true;
			Animator.speed = 0;
			RigidBody.velocity = Vector2.zero;
		}

		public void UnPause()
		{
			_paused = false;
			if(Animator != null) Animator.speed = 1;
		}

		private void OnDie()
		{
			_dead = true;
		}
	}
}