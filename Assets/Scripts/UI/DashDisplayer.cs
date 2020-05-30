using System;
using Entities.Player.Abilities;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class DashDisplayer : MonoBehaviour
    {
        [SerializeField] private DashAbility dashAbility;
        [SerializeField, Range(0, 1)] private float percentageLeftToBlink;
        [SerializeField] private float blinkSpeed = 1f;
        
        private CanvasGroup _canvasGroup;
        private bool _hided;
        private bool _blinkFadeIn;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            dashAbility.OnDash += Dash;
        }

        private void Update()
        {
            if (!_hided) return;
            var now = Time.time;
            if(now - dashAbility.LastDash > dashAbility.TimeBetweenDashes) Show();
            else if(now - dashAbility.LastDash > dashAbility.TimeBetweenDashes * percentageLeftToBlink) Blink();
        }

        private void Dash()
        {
            Hide();
        }

        private void Hide()
        {
            _canvasGroup.alpha = 0;
            _hided = true;
        }

        private void Show()
        {
            _canvasGroup.alpha = 1;
            _hided = false;
        }

        private void Blink()
        {
            if (_blinkFadeIn)
            {
                if (_canvasGroup.alpha < 0.99f) _canvasGroup.alpha += Time.deltaTime * blinkSpeed;
                else _blinkFadeIn = false;
            }
            else
            {
                if (_canvasGroup.alpha > 0.01f) _canvasGroup.alpha -= Time.deltaTime * blinkSpeed;
                else _blinkFadeIn = true;
            }
        }
    }
}