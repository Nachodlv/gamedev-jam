using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Utils.Audio
{
    public class AudioManager : MonoBehaviour, IPausable
    {
        [SerializeField] private int audioSourceQuantity;
        [SerializeField] private AudioSourcePooleable audioSourcePrefab;
        [SerializeField] private AudioSourcePooleable lowPassFilterPrefab;
        [SerializeField] private float fadeTime = 2f;

        public static AudioManager Instance;
        public bool Muted { get; private set; }

        private ObjectPooler<AudioSourcePooleable> _audioClipPooler;
        private ObjectPooler<AudioSourcePooleable> _lowPassFilterPooler;
        private ObjectPooler<AudioSourcePooleable> _backgroundMusicPooler;
        private bool _paused;

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

        public void PlaySound(AudioClip clip)
        {
            PlaySound(clip, AudioOptions.Default());
        }
        
        public void PlaySound(AudioClip clip, AudioOptions audioOptions )
        {
            if (Muted) return;
            audioOptions.LowPassFilter = _paused;
            var audioSource = audioOptions.LowPassFilter? _lowPassFilterPooler.GetNextObject() :_audioClipPooler.GetNextObject();
            audioSource.SetClip(clip);
            audioSource.SetVolume(audioOptions.Volume);
            audioSource.StartClip();
        }

        public void PlaySoundWithFade(AudioClip clip, float volume)
        {
            if (Muted) return;
            var audioSource = _audioClipPooler.GetNextObject();
            audioSource.SetClip(clip);
            StartCoroutine(AudioFades.FadeIn(audioSource.AudioSource, fadeTime, volume));
        }

        public void PlayBackgroundMusic(AudioClip clip, AudioOptions audioOptions)
        {
            var audioSource = _backgroundMusicPooler.GetNextObject();
            audioSource.AudioSource.clip = clip;
            audioSource.AudioSource.volume = audioOptions.Volume;
            audioSource.AudioSource.Play();
        }

        public void PauseBackgroundMusic(AudioClip clip)
        {
            GetAudioSource(clip)?.AudioSource.Pause();
        }

        public void PauseAllBackgroundMusic()
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
            foreach (var audioSourcePooleable in activeObject)
            {
                audioSourcePooleable.AudioSource.UnPause();
            }
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
            _lowPassFilterPooler = new ObjectPooler<AudioSourcePooleable>();
            var parent = _audioClipPooler.InstantiateObjects(audioSourceQuantity, audioSourcePrefab, "Audio Sources");
            var lowPassFilterParent = _lowPassFilterPooler.InstantiateObjects(audioSourceQuantity, lowPassFilterPrefab,
                "Low pass Audio Sources");
            DontDestroyOnLoad(parent);
            DontDestroyOnLoad(lowPassFilterParent);
        }

        private void InitializeBackgroundMusicPool()
        {
            _backgroundMusicPooler = new ObjectPooler<AudioSourcePooleable>();
            var parent = _backgroundMusicPooler.InstantiateObjects(2, audioSourcePrefab, "Background Music",
                audioSources =>
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

        public void Pause()
        {
            _paused = true;
        }

        public void UnPause()
        {
            _paused = false;
        }
    }
}