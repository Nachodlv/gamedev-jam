using System;
using System.Collections;
using Entities;
using UnityEngine;
using Utils;

namespace Platforms
{
	public class PlayerInteractablePlatform : MonoBehaviour, IPausable
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private float timeBeforeTriggering;
		protected Animator Animator => _animator;
		protected event Action OnTriggerEnter;
		protected bool Paused { get; private set; }

		private static readonly int PlayerEnterTrigger = Animator.StringToHash("playerEnter");
		private WaitSeconds _waitSeconds;
		private bool _triggered;

		protected virtual void Awake()
		{
			_waitSeconds = new WaitSeconds(this, PlayerEnter, timeBeforeTriggering);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!IsPlayer(other)) return;
			_waitSeconds.Wait();
		}
		
		protected static bool IsPlayer(Collider2D collider)
		{
			return collider.gameObject.CompareTag("Player");
		}

		private void PlayerEnter()
		{
			if (Paused)
			{
				_triggered = true;
				return;
			}
			_animator.SetTrigger(PlayerEnterTrigger);
			OnTriggerEnter?.Invoke();
		}

		public void Pause()
		{
			Paused = true;
			Animator.speed = 0;
		}

		public virtual void UnPause()
		{
			Paused = false;
			Animator.speed = 1;
			
			if (!_triggered) return;
			PlayerEnter();
			_triggered = false;
		}
	}
}