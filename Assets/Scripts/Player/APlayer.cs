using UnityEngine;

namespace Player
{
	public class APlayer : MonoBehaviour
	{
		[SerializeField] private Stats stats;

		public Stats Stats => stats;
	}
}