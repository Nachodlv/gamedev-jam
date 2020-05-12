using Entities.Player;
using UnityEngine;

namespace Entities.Grabbables
{
	public class MiniBattery: Grabbable
	{
		[SerializeField] private float healthQuantity;

		public float HealthQuantity
		{
			set => healthQuantity = value;
		}
		

		protected override void Grabbed(Grabber grabber)
		{
			var player = grabber.GetComponentInParent<APlayer>();
			if (player == null) return;
			player.UpdateHealth(player.Stats.Health + healthQuantity);
		}
	}
}