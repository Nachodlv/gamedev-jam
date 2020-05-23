using System;
using Entities.Enemy;
using Utils.Audio;
using UnityEngine;

namespace Entities.Enemy
{
    public class EnemyAudioHandler : MonoBehaviour
    {
        [Header("Audios")]
        [SerializeField] private AudioClip enemySlowAttack;
        
        [Header("References")]
        [SerializeField] private EnemyWeapon enemyWeapon;

        private void Awake()
        {
            // enemyWeapon.Shoot += () => PlaySound(EnemySlowAttack); // Implementar efecto cuando disparan enemigos (TODO)
        }
        
        private void PlaySound(AudioClip clip)
        {
            AudioManager.Instance.PlaySound(clip);
        }
    }
}