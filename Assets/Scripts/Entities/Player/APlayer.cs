using DefaultNamespace;
using UnityEngine;

namespace Player
{
	public class APlayer : MonoBehaviour, IHaveStats
	{
		[SerializeField] private Stats stats;

		public Stats Stats => stats;
	}
}