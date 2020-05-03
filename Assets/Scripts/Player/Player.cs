using UnityEngine;

namespace Player
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private Stats stats;

		public Stats Stats => stats;
	}
}