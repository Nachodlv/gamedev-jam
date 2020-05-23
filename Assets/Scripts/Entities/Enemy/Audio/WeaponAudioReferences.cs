using UnityEngine;
using Utils.Audio;

namespace Entities.Enemy
{
    [CreateAssetMenu(fileName = "Weapon Audio", menuName = "Audio/Weapon Audio", order = 1)]
    public class WeaponAudioReferences : ScriptableObject
    {
        public CustomAudioClip shoot;
    }
}