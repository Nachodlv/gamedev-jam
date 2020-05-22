using System.Collections.Generic;
using UnityEngine;

namespace Utils.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private int audioSourceQuantity;
        [SerializeField] private AudioSourcePooleable audioSourcePrefab;
        [SerializeField] private float fadeTime = 2f;

        public static AudioManager Instance;
        public bool Muted { get; private set; }

        private ObjectPooler<AudioSourcePooleable> _audioClipPooler;
        private ObjectPooler<AudioSourcePooleable> _backgroundMusicPooler;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }

            PoolAudioSources();
            InitializeBackgroundMusicPool();
        }

        public void PlaySound(AudioClip clip, float volume = 1)
        {
            if (Muted) return;
            var audioSource = _audioClipPooler.GetNextObject();
            audioSource.SetClip(clip);
            audioSource.SetVolume(volume);
            audioSource.StartClip();
        }

        public void PlaySoundWithFade(AudioClip clip, float volume)
        {
            if (Muted) return;
            var audioSource = _audioClipPooler.GetNextObject();
            audioSource.SetClip(clip);
            StartCoroutine(AudioFades.FadeIn(audioSource.AudioSource, fadeTime, volume));
        }

        public void PlaySound(AudioClip clip)
        {
            PlaySound(clip, 1);
        }
        

        public void PlayBackgroundMusic(AudioClip clip)
        {
            PauseAllBackgroundMusic();

            var audioSource = _backgroundMusicPooler.GetNextObject();
            audioSource.AudioSource.clip = clip;
            audioSource.AudioSource.Play();
        }

        public void PauseBackgroundMusic(AudioClip clip)
        {
            GetAudioSource(clip)?.AudioSource.Pause();
        }

        private void PauseAllBackgroundMusic()
        {
            foreach (var audioSourcePooleable in _backgroundMusicPooler.Objects)
            {
                audioSourcePooleable.AudioSource.Pause();
            }
        }

        public void ResumeBackgroundMusic(AudioClip clip)
        {
            GetAudioSource(clip)?.AudioSource.UnPause();
        }

        public void StopBackgroundMusic(AudioClip clip)
        {
            var audioSource = GetAudioSource(clip);
            audioSource?.Deactivate();
            var activeObject = _backgroundMusicPooler.ActiveObjects;
            if (activeObject.Count > 0) 
                activeObject[activeObject.Count - 1].AudioSource.UnPause();
        }
        
        public void FadeOutClip(AudioClip clip)
        {
            StartCoroutine(AudioFades.FadeOut(GetAudioSource(clip), fadeTime));
        }

        public void FadeOutClip(AudioClip clip, float velocity)
        {
            StartCoroutine(AudioFades.FadeOut(GetAudioSource(clip), velocity));
        }

        private void PoolAudioSources()
        {
            _audioClipPooler = new ObjectPooler<AudioSourcePooleable>();
            var parent = _audioClipPooler.InstantiateObjects(audioSourceQuantity, audioSourcePrefab, "Audio Sources");
            DontDestroyOnLoad(parent);
        }

        private void InitializeBackgroundMusicPool()
        {
            _backgroundMusicPooler = new ObjectPooler<AudioSourcePooleable>();
            var parent = _backgroundMusicPooler.InstantiateObjects(2, audioSourcePrefab, "Background Music", audioSources =>
            {
                foreach (var audioSource in audioSources)
                {
                    audioSource.AudioSource.loop = true;
                }
            });
            DontDestroyOnLoad(parent);
        }

        private AudioSourcePooleable GetAudioSource(AudioClip clip)
        {
            foreach (var audioSource in _backgroundMusicPooler.Objects)
            {
                if (audioSource.AudioSource.clip == clip) return audioSource;
            }

            return null;
        }
    }
}