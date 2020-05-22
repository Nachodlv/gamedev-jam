using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "Player Audio", menuName = "Audio/PlayerAudio", order = 1)]
    public class PlayerAudioReferences : ScriptableObject
    {
        public AudioClip swordDraw;
        public AudioClip attackClip;
        public AudioClip jumpClip;
        public AudioClip hitGroundClip;
        public AudioClip timeStopAbility;
        public AudioClip dieClip;
        public AudioClip walkingClip;
        public AudioClip continuousStoppedTime;
        public AudioClip timeStopEnd;
        public AudioClip dash;
        public AudioClip batteryPickUp;
        public AudioClip reflectBullet;
    }
}