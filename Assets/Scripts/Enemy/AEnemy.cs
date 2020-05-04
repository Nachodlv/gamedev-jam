using DefaultNamespace;
using UnityEngine;

namespace Enemy
{
	public class AEnemy: MonoBehaviour, IHasStats
	{
		public Stats Stats { get; }
		
	}
}