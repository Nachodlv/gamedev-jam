using System;
using Entities.Player;
using Levels;
using UnityEngine;

namespace DefaultNamespace
{
	public class GameController: MonoBehaviour
	{
		[SerializeField] private LevelManager levelManager;
		[SerializeField] private APlayer player;

		private void Awake()
		{
			player.OnDie += FinishLevel;
		}

		public void FinishLevel()
		{
			levelManager.FinishLevel();
		}
	}
}