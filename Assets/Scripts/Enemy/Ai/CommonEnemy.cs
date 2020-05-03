using System;
using Enemy.Ai.States;
using UnityEngine;

namespace Enemy.Ai
{
	[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
	public class CommonEnemy: MonoBehaviour
	{
		[SerializeField] private EnemyStats stats;
		[SerializeField] private Transform leftPosition;
		[SerializeField] private Transform rightPosition;
		
		public EnemyStats Stats => stats;
		public Animator Animator { get; private set; }
		public Rigidbody2D RigidBody { get; private set; }
		
		private StateMachine _stateMachine;
		private void Awake()
		{
			RigidBody = GetComponent<Rigidbody2D>();
			Animator = GetComponent<Animator>();
			_stateMachine = new StateMachine();
			
			_stateMachine.SetState(new IdleState(leftPosition, rightPosition,this));
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