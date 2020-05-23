namespace Utils.Audio
{
    public struct AudioOptions
    {
        public float Volume;
        public bool LowPassFilter;

        public static AudioOptions Default()
        {
            return new AudioOptions
            {
                Volume = 1,
                LowPassFilter =  false
            };
        }
    }
}