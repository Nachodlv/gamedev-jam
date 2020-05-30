using System;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;
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
        [SerializeField] private CanvasGroup[] buttonsToDisplay;
        
        private Button _button;
        private Image _image;
        private bool _paused;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            _button.onClick.AddListener(ButtonClicked);
            
            var controller = new InputAction(binding: "<Keyboard>/p");
            controller.performed += (_) => ButtonClicked();
            controller.Enable();
        }

        private void Start()
        {
            UnPause();
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
            ChangeAlphaButton(false);
        }

        public void UnPause()
        {
            Time.timeScale = 1;
            _paused = false;
            pausePanel.enabled = false;
            _image.sprite = pauseSprite;
            ChangeAlphaButton(true);
        }

        private void ChangeAlphaButton(bool hide)
        {
            foreach (var canvasGroup in buttonsToDisplay)
            {
                canvasGroup.alpha = hide ? 0 : 1;
                canvasGroup.interactable = !hide;
                canvasGroup.blocksRaycasts = !hide;
            }
        }
    }
}