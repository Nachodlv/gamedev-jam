using UnityEngine;
using Utils.Audio;

namespace Entities.Enemy
{
    [CreateAssetMenu(fileName = "Enemy Audio", menuName = "Audio/Enemy Audio", order = 1)]
    public class EnemyAudioReferences : ScriptableObject
    {
        public CustomAudioClip onSight;
    }
}