using System;
using System.Collections;
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
        [SerializeField] private int gameOverSceneIndex = 10;

        public event Action<LevelSettings> OnLevelChange;

        private int _currentLevel;
        private int _previousLevel;
        private CinemachineFramingTransposer _camera;
        private int _retryQuantity;

        private LevelSettings Currentlevel => levels[_currentLevel];
        private LevelSettings PreviousLevel => levels[_previousLevel];

        private void Awake()
        {
            _camera = FindObjectOfType<CinemachineVirtualCamera>()
                .GetCinemachineComponent<CinemachineFramingTransposer>();
            Timer.Instance.Begin();
            LoadLevel();
        }

        public void FinishLevel()
        {
            _retryQuantity = 0;
            _previousLevel = _currentLevel;
            if (_currentLevel >= levels.Length - 1)
            {
                GameOver();
                return;
            }
            _currentLevel++;
            LoadCurrentLevelWithFade(PreviousLevel.index);
        }

        public void ResetLevel()
        {
            if (_currentLevel == levels.Length - 1)
            {
                GameOver();
                return;
            }
            _retryQuantity++;
            LoadCurrentLevelWithFade(Currentlevel.index);
        }

        private void LoadCurrentLevelWithFade(int sceneToUnload)
        {
            LevelTransition.Instance.FadeIn();
            var unloadScene = SceneManager.UnloadSceneAsync(sceneToUnload);
            unloadScene.completed += (_) => LoadLevel();
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
            var playerTransform = player.transform;
            var previousPosition = playerTransform.position;
            playerTransform.position = Currentlevel.playerPosition;
            player.StartLevel(Currentlevel.time, _retryQuantity);
            _camera.OnTargetObjectWarped(player.transform, Currentlevel.playerPosition - (Vector2) previousPosition);
        }

        private void GameOver()
        {
            // yield return new WaitForSeconds(1);
            Timer.Instance.Stop();
            SceneManager.LoadScene(gameOverSceneIndex);
        }
        
    }
}