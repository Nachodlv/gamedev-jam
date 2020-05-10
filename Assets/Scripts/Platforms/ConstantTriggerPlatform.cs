using UnityEngine;

namespace Platforms
{
	public class ConstantTriggerPlatform: PlayerInteractablePlatform
	{
		private static readonly int PlayerExit = Animator.StringToHash("playerExit");
		private void OnTriggerExit2D(Collider2D other)
		{
			if (!IsPlayer(other)) return;
			
			Animator.SetTrigger(PlayerExit);
		}
	}
}