using DefaultNamespace;
using UnityEngine;

namespace Enemy
{
	public class AEnemy: MonoBehaviour, IHaveStats
	{
		public Stats Stats { get; }
		
	}
}