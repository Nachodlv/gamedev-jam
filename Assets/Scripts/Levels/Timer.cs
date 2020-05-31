using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Levels
{
    public class Timer : MonoBehaviour
    {
        public float CurrentTime { get; private set; }
        public bool Paused { get; private set; }
        public static Timer Instance;
        public float BestRun { get; private set; } = float.MaxValue;
        public bool HasBestRun { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (Paused) return;
            CurrentTime += Time.deltaTime;
        }

        public void Pause()
        {
            Paused = true;
        }

        public void Resume()
        {
            Paused = false;
        }

        public void Begin()
        {
            Paused = false;
            CurrentTime = 0;
        }

        public void Stop()
        {
            Pause();
            HasBestRun = true;
            BestRun = CurrentTime < BestRun ? CurrentTime : BestRun;
            CurrentTime = 0;
        }
    }
}