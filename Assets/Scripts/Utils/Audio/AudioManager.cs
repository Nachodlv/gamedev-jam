using UnityEngine;

namespace Utils.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager: MonoBehaviour
    {
        [SerializeField] private int audioSourceQuantity;
        [SerializeField] private AudioSourcePooleable audioSourcePrefab;
        [SerializeField] private float fadeTime = 2f;
        
        public static AudioManager Instance;
        public bool Muted { get; private set; }

        private AudioSource _audioSource;
        private ObjectPooler<AudioSourcePooleable> _pooler;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
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
        }

        private void Start()
        {
            _audioSource.loop = true;
            _audioSource.Play();
        }

        public void PlaySound(AudioClip clip, float volume = 1)
        {
            if (Muted) return;
            var audioSource = _pooler.GetNextObject();
            audioSource.SetClip(clip);
            audioSource.SetVolume(volume);
            audioSource.StartClip();
        }

        public void PlaySoundWithFade(AudioClip clip, float volume)
        {
            if (Muted) return;
            var audioSource = _pooler.GetNextObject();
            audioSource.SetClip(clip);
            StartCoroutine(AudioFades.FadeIn(audioSource.AudioSource, fadeTime, volume));
        } 
        
        public void PlaySound(AudioClip clip)
        {
            PlaySound(clip, 1);
        }

        public void Mute()
        {
            _audioSource.Pause();
            Muted = true;
        }

        public void UnMute()
        {
            _audioSource.Play();
            Muted = false;
        }
        
        public void ChangeClip(AudioClip clip)
        {
            _audioSource.clip = clip;
            if(!Muted) _audioSource.Play();
        }

        public void FadeOutClip()
        {
            StartCoroutine(AudioFades.FadeOut(_audioSource, fadeTime));
        }

        public void FadeOutClip(float velocity)
        {
            StartCoroutine(AudioFades.FadeOut(_audioSource, velocity));
        }

        private void PoolAudioSources()
        {
            _pooler = new ObjectPooler<AudioSourcePooleable>();
            _pooler.InstantiateObjects(audioSourceQuantity, audioSourcePrefab, "Audio Sources");
        }
    }
}