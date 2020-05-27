using Entities.Enemy.Enemies;
using Utils.Audio;
using UnityEngine;

namespace Entities.Enemy
{
    public class EnemyAudioHandler : MonoBehaviour
    {
        [Header("Audios")]
        [SerializeField] private EnemyAudioReferences enemyAudioReferences;
        
        [Header("References")]
        [SerializeField] private EnemyAi enemyAi;

        [Header("Configuration")] [SerializeField]
        private float timeBetweenPlayerSights = 2f;

        private float lastPlayerSight;
        private void Awake()
        {
            enemyAi.OnPlayerSight += () =>
            {
                var now = Time.time;
                if (now - lastPlayerSight < timeBetweenPlayerSights) return;
                lastPlayerSight = now;
                PlaySound(enemyAudioReferences.onSight);
            };
        }
        
        private void PlaySound(CustomAudioClip customAudioClip)
        {
            AudioManager.Instance.PlaySound(customAudioClip.audioClip, new AudioOptions
            {
                Volume =  customAudioClip.volume
            });
        }
    }
}