using System;
using Entities.Player.Abilities;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(StatBar))]
    public class TimeStopDisplayer : MonoBehaviour
    {
        [SerializeField] private TimeStopAbility timeStop;

        private StatBar _statBar;

        private void Awake()
        {
            _statBar = GetComponent<StatBar>();
        }

        private void Start()
        {
            _statBar.MaxValue = timeStop.TimeAvailableToStop;
            _statBar.CurrentValue = timeStop.TimeAvailableToStop;
        }

        private void Update()
        {
            _statBar.CurrentValue = timeStop.TimeAvailableToStop;
        }
    }
}