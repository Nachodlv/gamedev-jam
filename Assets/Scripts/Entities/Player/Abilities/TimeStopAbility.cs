using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Entities.Player.Abilities
{
	public class TimeStopAbility : MonoBehaviour
	{
		[SerializeField] private float maximumTime = 10f;
		[SerializeField] private float rechargingDelay = 2f;
		[SerializeField] private float rechargeRatio;
		[SerializeField] private Light2D universalLight;
		[SerializeField] private float lightIntensity = 0.2f;
		[SerializeField] private float changeLightSpeed = 1f;
		[SerializeField] private TrailRenderer trail;

		public IPausable[] Pausables
		{
			set => _pausables = value;
		}

		private IPausable[] _pausables;
		private float _timeAvailableToStop;
		private bool _paused;
		private float _unPausedTime;
		private float _initialLightIntensity;

		private void Awake()
		{
			Pausables = new IPausable[0];
			_timeAvailableToStop = maximumTime;
			_initialLightIntensity = universalLight.intensity;
			trail.emitting = false;
		}

		private void Update()
		{
			ChangeLightingIfNeeded();
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
			trail.emitting = true;
			foreach (var pausable in _pausables)
			{
				pausable.Pause();
			}
		}

		public void UnPause()
		{
			_unPausedTime = Time.time;
			_paused = false;
			trail.emitting = false;
			foreach (var pausable in _pausables)
			{
				pausable.UnPause();
			}
		}

		private void ChangeLightingIfNeeded()
		{
			if (_paused &&universalLight.intensity > lightIntensity)
			{
				universalLight.intensity -= Time.deltaTime * changeLightSpeed;
			} else if (!_paused && universalLight.intensity < _initialLightIntensity)
			{
				universalLight.intensity += Time.deltaTime * changeLightSpeed;
			}
		}
		
	}
}