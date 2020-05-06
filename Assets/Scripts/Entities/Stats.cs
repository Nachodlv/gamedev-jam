using System;
using UnityEngine;

[Serializable]
public class Stats
{
	[SerializeField] private float Health;
	public float Speed;

	public float CurrentHealth
	{
		get
		{
			if (!_initialized)
			{
				_currentHealth = Health;
				_initialized = true;
			}

			return _currentHealth;
		}
		set => _currentHealth = value;
	}

	private float _currentHealth;
	private bool _initialized;
	
	public void ResetHealth()
	{
		CurrentHealth = Health;
	}
}