using Cinemachine;
using Entities.Player;
using Levels;
using UnityEngine;

public class GameController: MonoBehaviour
{
	[SerializeField] private LevelManager levelManager;
	[SerializeField] private APlayer player;
		
	private void Awake()
	{
		player.OnResetLevel += ResetLevel;
	}

	public void FinishLevel()
	{
		levelManager.FinishLevel();
	}

	private void ResetLevel()
	{
		levelManager.ResetLevel();
	}
		
}