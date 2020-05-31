using System;
using UnityEngine;

namespace Utils.Audio
{
    [RequireComponent(typeof(Collider2D))]
    public class ChangeAudioOnTrigger : MonoBehaviour
    {
        [SerializeField] private CustomAudioClip audioClip;
        [SerializeField] private float fadeSpeed = 1f;

        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            AudioManager.Instance.StopAllBackgroundMusic(new AudioOptions
                {Volume = 1, FadeSpeed = fadeSpeed, WithFade = true});
            AudioManager.Instance.PlaySound(audioClip.audioClip,
                new AudioOptions {Volume = audioClip.volume, FadeSpeed = fadeSpeed, WithFade = true});
            _collider.enabled = false;
        }
    }
}