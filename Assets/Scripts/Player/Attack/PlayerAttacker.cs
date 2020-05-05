using System;
using DefaultNamespace;
using UnityEngine;

namespace Player.Attack
{
	[RequireComponent(typeof(CapsuleCollider2D))]
	public class PlayerAttacker : MonoBehaviour
	{
		[SerializeField] private Sword sword;
		[SerializeField] private CharacterController characterController;
		[SerializeField] private float timeBetweenAttacks = 1f;
		[SerializeField] private CharacterAnimator animator;
		
		public event Action OnAttack;

		private bool _swordDisplayed;
		private CapsuleCollider2D _collider;
		private RaycastHit2D[] _hits;
		private float _lastAttack;

		private void Awake()
		{
			_collider = GetComponent<CapsuleCollider2D>();
			_hits = new RaycastHit2D[5];
			animator.OnAttackAnimation += MakeAttack;
		}

		public void Attack()
		{
			if (!CanAttack()) return;
			_lastAttack = Time.time;
			OnAttack?.Invoke();
		}

		private void MakeAttack()
		{
			var myPosition = transform.position;
			var center = myPosition;
			center.x += (_collider.bounds.extents.x + sword.Range) * (characterController.FacingRight ? 1 : -1);
			var hitsQuantity = Physics2D.BoxCast(
				center, GetAttackRange(), 0, Vector2.zero, new ContactFilter2D(), _hits, 0);
			for (var i = 0; i < hitsQuantity; i++)
			{
				AttackCollider(_hits[i]);
			}
		}
		
		private void AttackCollider(RaycastHit2D hit)
		{
			var damageReceiver = hit.collider.GetComponent<DamageReceiver>();
			if (damageReceiver == null) return;
			damageReceiver.ReceiveDamage(sword.Damage, transform.position);
		}

		private void OnDrawGizmos()
		{
			var myTransform = transform;
			var center = myTransform.position;
			center.x += (GetComponent<CapsuleCollider2D>().bounds.extents.x + sword.Range) * (characterController.FacingRight ? 1 : -1);
			var size = Vector2.one * GetComponent<CapsuleCollider2D>().bounds.size.y;
			size.x = sword.Range;
			Gizmos.DrawCube(center,
				size);
		}

		private bool CanAttack()
		{
			return Time.time - _lastAttack > timeBetweenAttacks;
		}

		private Vector2 GetAttackRange()
		{
			var size = Vector2.one * _collider.bounds.size.y;
			size.x = sword.Range;
			return size;
		}
	}
}