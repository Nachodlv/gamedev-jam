using Entities.Player;
using UnityEngine;

namespace Entities.Grabbables
{
	public class MiniBattery: Grabbable
	{
		[SerializeField] private float healthQuantity;
		protected override void Grabbed(Grabber grabber)
		{
			var player = grabber.GetComponent<APlayer>();
			if (player == null) return;
			player.Stats.Health += healthQuantity;
		}
	}
}