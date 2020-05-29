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
		private CinemachineFramingTransposer _camera;
		private int _retryQuantity;

		private LevelSettings Currentlevel => levels[_currentLevel];
		private LevelSettings PreviousLevel => levels[_previousLevel];

		private void Awake()
		{
			_camera = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
			LoadLevel();
		}

		public void FinishLevel()
		{
			_retryQuantity = 0;
			_previousLevel = _currentLevel;
			if (_currentLevel >= levels.Length - 1) _currentLevel = 0;
			else _currentLevel++;
			LoadCurrentLevelWithFade();
			SceneManager.UnloadSceneAsync(PreviousLevel.index);
		}

		public void ResetLevel()
		{
			_retryQuantity++;
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
				OnLevelChange?.Invoke(Currentlevel);
			};
		}

		private void SetUpPlayer()
		{
			var previousPosition = player.transform.position;
			player.transform.position = Currentlevel.playerPosition;
			player.StartLevel(Currentlevel.time, _retryQuantity);
			// player.gameObject.SetActive(false);
			// player.gameObject.SetActive(true);
			_camera.OnTargetObjectWarped(player.transform, Currentlevel.playerPosition - (Vector2) previousPosition);
			// _camera.transform.position = player.transform.position;
		}
		
		
	}
}