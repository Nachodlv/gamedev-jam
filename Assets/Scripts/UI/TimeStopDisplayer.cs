using System;
using Entities.Player.Abilities;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(SpritesProgressBar))]
    public class TimeStopDisplayer : MonoBehaviour
    {
        [SerializeField] private TimeStopAbility timeStop;

        private SpritesProgressBar _spritesProgressBar;

        private void Awake()
        {
            _spritesProgressBar = GetComponent<SpritesProgressBar>();
        }

        private void Start()
        {
            _spritesProgressBar.SetUpMaxValue(timeStop.TimeAvailableToStop);
        }

        private void Update()
        {
            _spritesProgressBar.UpdateValue(timeStop.TimeAvailableToStop);
        }
    }
}