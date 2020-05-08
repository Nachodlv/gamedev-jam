using System;
using UnityEngine;

namespace Utils
{
	public class AxisDetection
	{
		private readonly Action<float> _singlePress;
		private readonly Action<float> _doublePress;
		private readonly float _timeBetweenPresses;

		private float _lastTimePress;
		private bool _isPressed;
		private bool _positiveValue;

		public AxisDetection(Action<float> singlePress, Action<float> doublePress, float timeBetweenPresses)
		{
			_singlePress = singlePress;
			_doublePress = doublePress;
			_timeBetweenPresses = timeBetweenPresses;
		}

		public void Update(float axis)
		{
			if (Math.Abs(axis) > 0.01f)
			{
				if (!_isPressed && Time.time - _lastTimePress < _timeBetweenPresses && GoingToTheSameDirection(axis))
				{
					_doublePress(axis);
					return;
				}
				_singlePress(axis);
				_isPressed = true;
				_positiveValue = axis > 0;
				_lastTimePress = Time.time;
			}
			else
			{
				_isPressed = false;
			}
		}

		private bool GoingToTheSameDirection(float axis)
		{
			return (_positiveValue && axis > 0) || (!_positiveValue && axis < 0);
		}
	}
}