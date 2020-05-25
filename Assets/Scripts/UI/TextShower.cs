using System;
using System.Collections;
using Entities.Player;
using UnityEngine;
using Utils;

namespace UI
{
    public class TextShower : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float timeShowing = 1f;
        [SerializeField] private float fadeSpeed = 1f;
        [SerializeField] private Collider2D collider2D;

        private Func<IEnumerator> _fadeIn;
        private Func<IEnumerator> _fadeOut;
        private WaitSeconds _waitSeconds;
        private bool showed;

        private void Awake()
        {
            _fadeIn = FadeIn;
            _fadeOut = FadeOut;
            canvasGroup.alpha = 0;
            _waitSeconds = new WaitSeconds(this, () => StartCoroutine(_fadeOut()), timeShowing);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponentInChildren<APlayer>();
            if (player == null) return;
            ShowText();
            collider2D.enabled = false;
        }

        private void ShowText()
        {
            StartCoroutine(_fadeIn());
            _waitSeconds.Wait();
        }

        private IEnumerator FadeIn()
        {
            while (canvasGroup.alpha < 0.99f)
            {
                canvasGroup.alpha += Time.deltaTime * fadeSpeed;
                yield return null;
            }
        }

        private IEnumerator FadeOut()
        {
            while (canvasGroup.alpha > 0.01f)
            {
                canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
                yield return null;
            }
        }
    }
}