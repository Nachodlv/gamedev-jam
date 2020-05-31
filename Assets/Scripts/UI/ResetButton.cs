using System;
using Levels;
using UnityEngine;
using UnityEngine.UI;
using Utils.Audio;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ResetButton : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private PauseButton pauseButton;
        [SerializeField] private AudioClip audioClip;
        
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ButtonClicked);
        }

        private void ButtonClicked()
        {
            AudioManager.Instance.PlaySound(audioClip);
            pauseButton.UnPause();
            levelManager.ResetLevel();
        }
    }
}