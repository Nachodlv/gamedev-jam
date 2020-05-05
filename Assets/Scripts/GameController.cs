using Levels;
using UnityEngine;

namespace DefaultNamespace
{
	public class GameController: MonoBehaviour
	{
		[SerializeField] private LevelManager levelManager;

		public void FinishLevel()
		{
			levelManager.FinishLevel();
		}
	}
}