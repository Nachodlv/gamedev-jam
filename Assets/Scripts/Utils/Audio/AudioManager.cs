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
            audioOptions.LowPassFilter = _paused;
            var audioSource = audioOptions.LowPassFilter? _lowPassFilterPooler.GetNextObject() :_audioClipPooler.GetNextObject();
            audioSource.SetClip(clip);
            audioSource.SetVolume(audioOptions.Volume);
            audioSource.StartClip();
        }

        public void PlayBackgroundMusic(AudioClip clip, AudioOptions audioOptions)
        {
            var audioSource = _backgroundMusicPooler.GetNextObject();
            audioSource.AudioSource.clip = clip;
            audioSource.AudioSource.volume = audioOptions.Volume;
            audioSource.AudioSource.Play();
        }

        public void PauseAllBackgroundMusic()
        {
            foreach (var audioSourcePooleable in _backgroundMusicPooler.Objects)
            {
                audioSourcePooleable.AudioSource.Pause();
            }
        }

        public void StopBackgroundMusic()
        {
            var activeObjects = _backgroundMusicPooler.ActiveObjects;
            if(activeObjects.Count > 0) StopBackgroundMusic(activeObjects[0].AudioSource.clip);
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

        public void Mute() => ChangeMute(true);
        public void UnMute() => ChangeMute(false);

        private void ChangeMute(bool mute)
        {
            foreach (var audioSourcePooleable in _audioClipPooler.Objects)
            {
                audioSourcePooleable.AudioSource.mute = mute;
            }

            foreach (var audioSourcePooleable in _backgroundMusicPooler.Objects)
            {
                audioSourcePooleable.AudioSource.mute = mute;
            }
        }
    }
}