using System;
using Levels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils.Audio;

namespace UI
{
    [RequireComponent(typeof(Button), typeof(Animator))]
    public class MenuButton: MonoBehaviour
    {
        
        private Animator _animator;
        private static readonly int Tap = Animator.StringToHash("tap");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            GetComponent<Button>().onClick.AddListener(TriggerButtonAnimation);
        }
        
        [SerializeField] private AudioClip clip;

        private void TriggerButtonAnimation()
        {
            LevelTransition.Instance.FadeIn();
            _animator.SetTrigger(Tap);
            AudioManager.Instance.PlaySound(clip);
        }

        private void FinishAnimation()
        {
            AudioManager.Instance.StopBackgroundMusic();
            SceneManager.LoadScene(1);
        }
    }
}