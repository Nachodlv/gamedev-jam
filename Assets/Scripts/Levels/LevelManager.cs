using System;
using System.Linq;
using Cinemachine;
using Entities;
using Entities.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
	public class LevelManager : MonoBehaviour
	{
		[SerializeField] private LevelSettings[] levels;
		[SerializeField] private APlayer player;

		public event Action<LevelSettings> OnLevelChange;
		
		private int _currentLevel;
		private int _previousLevel;
		private Transform _camera;

		private LevelSettings Currentlevel => levels[_currentLevel];
		private LevelSettings PreviousLevel => levels[_previousLevel];

		private void Awake()
		{
			_camera = Camera.main.transform;
			LoadLevel();
		}

		public void FinishLevel()
		{
			_previousLevel = _currentLevel;
			if (_currentLevel >= levels.Length - 1) _currentLevel = 0;
			else _currentLevel++;
			LoadCurrentLevelWithFade();
			SceneManager.UnloadSceneAsync(PreviousLevel.index);
		}

		public void ResetLevel()
		{
			SceneManager.UnloadSceneAsync(Currentlevel.index);
			LoadCurrentLevelWithFade();
		}
		
		private void LoadCurrentLevelWithFade()
		{
			LevelTransition.Instance.FadeIn();
			LoadLevel();
		}

		private void LoadLevel()
		{
			var loadSceneAsync = SceneManager.LoadSceneAsync(Currentlevel.index, LoadSceneMode.Additive);
			loadSceneAsync.completed += operation =>
			{
				SetUpPlayer();
				LevelTransition.Instance.FadeOut();
				_camera.transform.position = player.transform.position;
				OnLevelChange?.Invoke(Currentlevel);
			};
		}

		private void SetUpPlayer()
		{
			player.GetComponent<Rigidbody2D>().position = Currentlevel.playerPosition;
			player.StartLevel(Currentlevel.time);
		}
		
		
	}
}