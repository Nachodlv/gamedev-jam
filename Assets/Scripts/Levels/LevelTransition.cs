using System;
using UnityEngine;

namespace Levels
{
    [RequireComponent(typeof(Animator))]
    public class LevelTransition: MonoBehaviour
    {
        public static LevelTransition Instance { get; private set; }

        private Animator _animator;
        private static readonly int FadeInTrigger = Animator.StringToHash("fadeIn");
        private static readonly int fadeOutTrigger = Animator.StringToHash("fadeOut");

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            _animator = GetComponent<Animator>();
        }

        public void FadeIn()
        {
            _animator.SetTrigger(FadeInTrigger);
        }

        public void FadeOut()
        {
            _animator.SetTrigger(fadeOutTrigger);
        }
    }
}