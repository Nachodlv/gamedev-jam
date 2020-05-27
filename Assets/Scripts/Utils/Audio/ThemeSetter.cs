using UnityEngine;

namespace Utils.Audio
{
    public class ThemeSetter: MonoBehaviour
    {
        [SerializeField] private CustomAudioClip audioClip;
        
        private void Start()
        {
            AudioManager.Instance.PlayBackgroundMusic(audioClip.audioClip, new AudioOptions{Volume = audioClip.volume});
        }
    }
}