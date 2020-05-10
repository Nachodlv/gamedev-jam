using System;
using System.Collections;
using UnityEngine;

namespace Platforms
{
	public class TimePlatform: PlayerInteractablePlatform
	{
		[SerializeField] private float timeToDeactivate;

		private static readonly int PlayerExit = Animator.StringToHash("playerExit");

		private WaitForSeconds _waitingTime;
		private Func<IEnumerator> _waitCoroutine;

		protected override void Awake()
		{
			base.Awake();
			OnTriggerEnter += TriggerEnter;
			_waitingTime = new WaitForSeconds(timeToDeactivate);
			_waitCoroutine = WaitCoroutine;
		}

		private void TriggerEnter()
		{
			StartCoroutine(_waitCoroutine());
		}

		private IEnumerator WaitCoroutine()
		{
			yield return _waitingTime;
			Animator.SetTrigger(PlayerExit);
		}
		
	}
}