using System;
using System.Globalization;
using Levels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TimeDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI minutes;
        [SerializeField] private TextMeshProUGUI seconds;
        [SerializeField] private bool displayBestRun;

        private void Start()
        {
            var timer = Timer.Instance;
            if (!displayBestRun) return;
            
            if (timer.HasBestRun)
            {
                SetUpTime(timer.BestRun);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if(displayBestRun) return;
            var timer = Timer.Instance;
            if (timer.Paused) return;
            SetUpTime(timer.CurrentTime);
        }

        private void SetUpTime(float time)
        {
            minutes.text = Mathf.Floor(time / 60).ToString("00");
            seconds.text = (time  % 60).ToString("00");
        }
        
    }
}