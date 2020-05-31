using UnityEngine;

namespace Utils.Audio
{
    public class ThemeSetter: MonoBehaviour
    {
        [SerializeField] private CustomAudioClip audioClip;
        [SerializeField] private bool pauseOtherBackgroundMusic;
        
        private void Start()
        {
            if(pauseOtherBackgroundMusic) AudioManager.Instance.StopAllBackgroundMusic();
            AudioManager.Instance.PlayBackgroundMusic(audioClip.audioClip, new AudioOptions{Volume = audioClip.volume});
        }
    }
}