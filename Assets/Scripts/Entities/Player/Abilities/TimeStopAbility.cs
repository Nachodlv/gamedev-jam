using System;
using System.Linq;
using UnityEngine;

namespace Entities.Player
{
	public class TimeStopAbility : MonoBehaviour
	{
		[SerializeField] private float maximumTime = 10f;
		[SerializeField] private float rechargingDelay = 2f;
		[SerializeField] private float rechargeRatio;
		
		public IPausable[] Pausables
		{
			set => _pausables = value;
		}

		public event Action OnTimeStop;
		
		private IPausable[] _pausables;
		private float _timeAvailableToStop;
		private bool _paused;
		private float _unPausedTime;

		private void Awake()
		{
			Pausables = new IPausable[0];
			_timeAvailableToStop = maximumTime;
		}

		private void Update()
		{
			if (!_paused)
			{
				if (_timeAvailableToStop >= maximumTime || Time.time - _unPausedTime < rechargingDelay) return;
				_timeAvailableToStop += rechargeRatio * Time.deltaTime;
				return;
			}
			if(_timeAvailableToStop <= 0) UnPause();
			_timeAvailableToStop -= Time.deltaTime;
		}

		public void Pause()
		{
			if (_paused)
			{
				UnPause();
				return;
			}

			_paused = true;
			_pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>().ToArray();

			foreach (var pausable in _pausables)
			{
				pausable.Pause();
			}
			OnTimeStop?.Invoke();
		}

		public void UnPause()
		{
			_unPausedTime = Time.time;
			_paused = false;
			foreach (var pausable in _pausables)
			{
				pausable.UnPause();
			}
		}
	}
}