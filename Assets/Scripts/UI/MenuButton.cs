using System;
using Levels;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils.Audio;

namespace UI
{
    [RequireComponent(typeof(Button), typeof(Animator))]
    public class MenuButton: MonoBehaviour
    {
        [SerializeField] private AudioClip clip;

        private Animator _animator;
        private static readonly int Tap = Animator.StringToHash("tap");
        private InputAction _action;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            GetComponent<Button>().onClick.AddListener(TriggerButtonAnimation);
            _action = new InputAction(binding: "/*/<button>");
            _action.performed += (_) => TriggerButtonAnimation();
            _action.Enable();
        }
        

        private void TriggerButtonAnimation()
        {
            _action.Dispose();
            // LevelTransition.Instance.FadeIn();
            _animator.SetTrigger(Tap);
            AudioManager.Instance.PlaySound(clip);
        }

        private void FinishAnimation()
        {
            AudioManager.Instance.StopAllBackgroundMusic();
            SceneManager.LoadScene(1);
        }
    }
}