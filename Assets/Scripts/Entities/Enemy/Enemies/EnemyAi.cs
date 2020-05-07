using Enemy;
using Entities.Player;
using UnityEngine;
using Utils;

namespace Entities.Enemy.Enemies
{
	public abstract class EnemyAi: MonoBehaviour, IPausable
	{
		[SerializeField] private Stats stats;
		[SerializeField] private Animator animator;
		[SerializeField] protected SpriteRenderer spriteRenderer;
		[SerializeField] protected float visionRange = 5f;
		[SerializeField] protected EnemyWeapon enemyWeapon;
		[SerializeField] private LayerMask ignoredLayers;
		
		public Stats Stats => stats;
		public Animator Animator => animator;
		public Rigidbody2D RigidBody { get; private set; }

		protected StateMachine StateMachine;
		protected Transform Player;

		private DistanceDetector _distanceDetector;
		private bool _paused;
		private void Awake()
		{
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
			Animator.speed = 1;
		}
	}
}