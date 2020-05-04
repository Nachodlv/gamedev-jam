using System;
using UnityEngine;

namespace Player.Attack
{
	[RequireComponent(typeof(CapsuleCollider2D))]
	public class PlayerAttacker: MonoBehaviour
	{
		[SerializeField] private Sword sword;
		
		public event Action OnAttack;

		private bool _swordDisplayed;
		private CapsuleCollider2D _collider;

		private void Awake()
		{
			_collider = GetComponent<CapsuleCollider2D>();
		}

		public void Attack()
		{
			OnAttack?.Invoke();

			if (!_swordDisplayed)
			{
				_swordDisplayed = true;
				return;
			}
			var hit = Physics2D.BoxCast(transform.position, Vector2.one * sword.Range, 0, Vector2.zero);
			if (hit.collider != null)
			{
				Debug.Log("I hit something!");
			}
		}

		public void HideSword()
		{
			_swordDisplayed = false;
		}

		private void OnDrawGizmos()
		{
			var myTransform = transform;
			Gizmos.DrawCube(myTransform.right.x * (myTransform.position + _collider.bounds.extents), Vector3.one * sword.Range);
		}
	}
}