using System;
using UnityEngine;

namespace Utils.Audio
{
    [Serializable]
    public class CustomAudioClip
    {
        public AudioClip audioClip;
        [Range(0,1)] public float volume = 1;
    }
}