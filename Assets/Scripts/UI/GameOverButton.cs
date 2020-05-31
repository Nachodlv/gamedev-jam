using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils.Audio;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class GameOverButton : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ButtonClicked);
        }

        private void ButtonClicked()
        {
            AudioManager.Instance.PlaySound(clip);
            SceneManager.LoadScene(0);
        }
    }
}