using System;
using UnityEngine;

namespace Player.Attack
{
	[RequireComponent(typeof(CapsuleCollider2D))]
	public class PlayerAttacker : MonoBehaviour
	{
		[SerializeField] private Sword sword;
		[SerializeField] private CharacterController characterController;
		
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

			
			// var hitDirection = (characterController.FacingRight ? 1 : -1) * Vector2.right;
			var bounds = _collider.bounds.size;
			bounds.x = sword.Range * (characterController.FacingRight ? 1 : -1);
			var center = transform.position;
			center.x += _collider.bounds.size.x * (characterController.FacingRight ? 1 : -1);
			var hit = Physics2D.BoxCast(center,
				Vector2.one * sword.Range, 0, Vector2.zero);
			if (hit.collider != null)
			{
				Debug.Log("I hit something! " + hit.collider.name);
			}
		}

		public void HideSword()
		{
			_swordDisplayed = false;
		}

		private void OnDrawGizmos()
		{
			var myTransform = transform;
			var center = myTransform.position;
			center.x += _collider.bounds.size.x * (characterController.FacingRight ? 1 : -1);

			Gizmos.DrawCube(center,
				Vector3.one * sword.Range);
		}
	}
}