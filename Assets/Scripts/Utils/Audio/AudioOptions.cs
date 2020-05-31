namespace Utils.Audio
{
    public struct AudioOptions
    {
        public float Volume;
        public bool LowPassFilter;
        public bool WithFade;
        public float FadeSpeed;

        public static AudioOptions Default()
        {
            return new AudioOptions
            {
                Volume = 1,
                LowPassFilter =  false,
                WithFade = false,
                FadeSpeed = 1,
            };
        }
    }
}