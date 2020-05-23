using System;
using UnityEngine;

namespace Entities.Player
{
    [CreateAssetMenu(fileName = "Player Audio", menuName = "Audio/PlayerAudio", order = 1)]
    public class PlayerAudioReferences : ScriptableObject
    {
        public CustomAudioClip swordDraw;
        public CustomAudioClip attackClip;
        public CustomAudioClip jumpClip;
        public CustomAudioClip hitGroundClip;
        public CustomAudioClip timeStopAbility;
        public CustomAudioClip dieClip;
        public CustomAudioClip walkingClip;
        public CustomAudioClip continuousStoppedTime;
        public CustomAudioClip timeStopEnd;
        public CustomAudioClip dash;
        public CustomAudioClip batteryPickUp;
        public CustomAudioClip reflectBullet;
    }

    [Serializable]
    public class CustomAudioClip
    {
        public AudioClip audioClip;
        [Range(0,1)] public float volume = 1;
    }
}