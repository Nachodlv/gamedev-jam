using System;
using UnityEngine;

[Serializable]
public class Stats
{
	[SerializeField] private float health;
	[SerializeField] private float speed;
	public float Speed => speed;

	public float Health
	{
		get => health;
		set => health = value;
	}

	private float _currentHealth;
	private bool _initialized;
	
}