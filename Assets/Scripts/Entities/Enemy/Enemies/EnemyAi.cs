﻿using System;
 using Entities.Player;
 using Player;
using UnityEngine;
using Utils;

namespace Enemy.Ai
{
	public abstract class EnemyAi: MonoBehaviour
	{
		[SerializeField] private Stats stats;
		[SerializeField] private Animator animator;
		[SerializeField] protected SpriteRenderer spriteRenderer;
		[SerializeField] protected float visionRange = 5f;
		[SerializeField] protected EnemyWeapon enemyWeapon;

		public Stats Stats => stats;
		public Animator Animator => animator;
		public Rigidbody2D RigidBody { get; private set; }

		protected StateMachine StateMachine;
		private DistanceDetector _distanceDetector;
		private int _raycastLayer;
		protected Transform Player;
		private void Awake()
		{
			_raycastLayer = ~ LayerMask.GetMask($"Enemy");
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
			StateMachine.Tick();
		}

		private void FixedUpdate()
		{
			StateMachine.FixedTick();
		}
		
		protected bool PlayerInsideRange()
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
		
		protected abstract void SetUpStates();
	}
}