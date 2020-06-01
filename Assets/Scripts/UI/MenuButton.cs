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
        private InputAction _spaceAction;
        private InputAction _enterAction;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            GetComponent<Button>().onClick.AddListener(TriggerButtonAnimation);
            _spaceAction = new InputAction(binding: "/<Keyboard>/space");
            _enterAction = new InputAction(binding: "/<Keyboard>/enter");
            _spaceAction.performed += (_) => TriggerButtonAnimation();
            _enterAction.performed += (_) => TriggerButtonAnimation();
            _spaceAction.Enable();
            _enterAction.Enable();
        }
        

        private void TriggerButtonAnimation()
        {
            _spaceAction.Dispose();
            _enterAction.Dispose();
            // LevelTransition.Instance.FadeIn();
            _animator.SetTrigger(Tap);
            AudioManager.Instance.PlaySound(clip);
        }

        private void FinishAnimation()
        {
            AudioManager.Instance.StopAllBackgroundMusic(AudioOptions.Default());
            SceneManager.LoadScene(1);
        }
    }
}