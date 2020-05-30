using System;
using UnityEngine;
using UnityEngine.UI;
using Utils.Audio;

namespace UI
{
    [RequireComponent(typeof(Button), typeof(Image))]
    public class MuteButton : MonoBehaviour
    {
        [SerializeField] private Sprite mutedSprite;
        [SerializeField] private Sprite unMutedSprite;

        private Image _image;
        private bool muted;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
            GetComponent<Button>().onClick.AddListener(ButtonClicked);
        }

        private void ButtonClicked()
        {
            if(muted) UnMute();
            else Mute();
        }

        private void Mute()
        {
            AudioManager.Instance.Mute();
            _image.sprite = mutedSprite;
            muted = true;
        }

        private void UnMute()
        {
            AudioManager.Instance.UnMute();
            _image.sprite = unMutedSprite;
            muted = false;
        }
    }
}