using System;
using System.Collections;
using UnityEngine;
using Utils;

namespace Platforms
{
	public class TimePlatform: PlayerInteractablePlatform
	{
		[SerializeField] private float timeToDeactivate;

		private static readonly int PlayerExitTrigger = Animator.StringToHash("playerExit");

		private WaitSeconds _waitSeconds;
		private bool _triggered;

		protected override void Awake()
		{
			base.Awake();
			OnTriggerEnter += TriggerEnter;
			_waitSeconds = new WaitSeconds(this, PlayerExit, timeToDeactivate);
		}

		private void TriggerEnter()
		{
			_waitSeconds.Wait();
		}

		private void PlayerExit()
		{
			if (Paused)
			{
				_triggered = true;
				return;
			}
			Animator.SetTrigger(PlayerExitTrigger);
		}

		public override void UnPause()
		{
			base.UnPause();
			if (!_triggered) return;
			TriggerEnter();
			_triggered = false;
		}
	}
}