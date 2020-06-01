using System;
using UnityEngine;

namespace Entities.Player
{
    public class RestoreDashOnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<APlayer>();
            if (player == null) return;
            player.DashAbility.RestoreDash();
        }
    }
}