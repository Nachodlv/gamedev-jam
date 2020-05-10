using System;
using System.Collections;
using UnityEngine;

namespace Platforms
{
	public class PlayerInteractablePlatform : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private float timeBeforeTriggering;
		protected Animator Animator => _animator;
		protected event Action OnTriggerEnter;

		private WaitForSeconds _waitingTime;
		private Func<IEnumerator> _waitFunction;
		private Coroutine _waitCoroutine;
		private static readonly int PlayerEnter = Animator.StringToHash("playerEnter");

		protected virtual void Awake()
		{
			_waitingTime = new WaitForSeconds(timeBeforeTriggering);
			_waitFunction = WaitTime;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!IsPlayer(other)) return;
			StartCoroutine(_waitFunction());
		}
		
		protected static bool IsPlayer(Collider2D collider)
		{
			return collider.gameObject.CompareTag("Player");
		}

		private IEnumerator WaitTime()
		{
			yield return _waitingTime;
			_animator.SetTrigger(PlayerEnter);
			OnTriggerEnter?.Invoke();
		}
	}
}