using System;
using Input;
using UnityEngine;
using UnityEngine.UI;
using Utils.Audio;

namespace UI
{
    [RequireComponent(typeof(Button), typeof(Image))]
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Sprite pauseSprite;
        [SerializeField] private Sprite resumeSprite;
        [SerializeField] private AudioClip buttonClicked;
        [SerializeField] private Image pausePanel;
        
        private Button _button;
        private Image _image;
        private bool _paused;
        
        private void Awake()
        {
            pausePanel.enabled = false;
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            _button.onClick.AddListener(ButtonClicked);
            
            var controller = new InputActionController();
            controller.Configuration.Pause.performed += (_) => ButtonClicked();
        }

        private void ButtonClicked()
        {
            AudioManager.Instance.PlaySound(buttonClicked);
            if(_paused) UnPause();
            else Pause();
        }

        private void Pause()
        {
            Time.timeScale = 0;
            _paused = true;
            pausePanel.enabled = true;
            _image.sprite = resumeSprite;
        }

        private void UnPause()
        {
            Time.timeScale = 1;
            _paused = false;
            pausePanel.enabled = false;
            _image.sprite = pauseSprite;
        }
    }
}