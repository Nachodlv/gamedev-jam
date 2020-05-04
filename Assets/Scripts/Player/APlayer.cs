using DefaultNamespace;
using UnityEngine;

namespace Player
{
	public class APlayer : MonoBehaviour, IHasStats
	{
		[SerializeField] private Stats stats;

		public Stats Stats => stats;
	}
}