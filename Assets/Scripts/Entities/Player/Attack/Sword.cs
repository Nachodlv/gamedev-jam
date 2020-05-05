using UnityEngine;

namespace Player.Attack
{
	public class Sword : MonoBehaviour
	{
		[SerializeField] private float range;
		[SerializeField] private float damage;

		public float Range => range;
		public float Damage => damage;
	}
}