using System;
using System.Linq;
using Cinemachine;
using Entities;
using Entities.Player;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
	public class LevelManager : MonoBehaviour
	{
		[SerializeField] private LevelSettings[] levels;
		[SerializeField] private APlayer player;
		[SerializeField] private Animator levelTransition;
		
		private int _currentLevel;
		private int _previousLevel;
		private static readonly int FadeIn = Animator.StringToHash("fadeIn");
		private static readonly int FadeOut = Animator.StringToHash("fadeOut");

		private LevelSettings Currentlevel => levels[_currentLevel];
		private LevelSettings PreviousLevel => levels[_previousLevel];
		
		private void Awake()
		{
			LoadCurrentLevel();
		}

		public void FinishLevel()
		{
			_previousLevel = _currentLevel;
			if (_currentLevel >= levels.Length - 1) _currentLevel = 0;
			else _currentLevel++;
			LoadCurrentLevel();
			SceneManager.UnloadSceneAsync(PreviousLevel.index);
		}

		public void ResetLevel()
		{
			SceneManager.UnloadSceneAsync(PreviousLevel.index);
			LoadCurrentLevel();
		}
		
		private void LoadCurrentLevel()
		{
			levelTransition.SetTrigger(FadeIn);
			var loadSceneAsync = SceneManager.LoadSceneAsync(Currentlevel.index, LoadSceneMode.Additive);
			loadSceneAsync.completed += operation =>
			{
				// SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(Currentlevel.index));
				player.transform.position = Currentlevel.playerPosition;
				levelTransition.SetTrigger(FadeOut);
				SetUpPlayer();
			};
		}

		private void SetUpPlayer()
		{
			player.TimeStopAbility.Pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>().ToArray();
		}
		
		
	}
}