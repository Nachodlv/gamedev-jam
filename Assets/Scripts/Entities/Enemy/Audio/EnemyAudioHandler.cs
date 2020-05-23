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

        private void Awake()
        {
            enemyAi.OnPlayerSight += () => PlaySound(enemyAudioReferences.onSight);
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