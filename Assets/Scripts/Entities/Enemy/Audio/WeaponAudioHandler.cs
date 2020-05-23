using System;
using UnityEngine;
using Utils.Audio;

namespace Entities.Enemy
{
    [RequireComponent(typeof(EnemyWeapon))]
    public class WeaponAudioHandler : MonoBehaviour
    {
        [SerializeField] private WeaponAudioReferences weaponAudioReferences;

        private EnemyWeapon _enemyWeapon;

        private void Awake()
        {
            _enemyWeapon = GetComponent<EnemyWeapon>();
            _enemyWeapon.OnShoot += () => AudioManager.Instance.PlaySound(weaponAudioReferences.shoot.audioClip,
                new AudioOptions {Volume = weaponAudioReferences.shoot.volume});
        }
    }
}