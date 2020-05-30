using System;
using Levels;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ResetButton : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private PauseButton pauseButton;
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ButtonClicked);
        }

        private void ButtonClicked()
        {
            pauseButton.UnPause();
            levelManager.ResetLevel();
        }
    }
}