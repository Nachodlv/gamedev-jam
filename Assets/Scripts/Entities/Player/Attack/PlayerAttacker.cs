using System;
using Entities.Enemy;
using UnityEngine;
using CharacterController = Entities.Player.Movement.CharacterController;

namespace Entities.Player.Attack
{
	[RequireComponent(typeof(Collider2D))]
	public class PlayerAttacker : MonoBehaviour
	{
		[SerializeField] private Sword sword;
		[SerializeField] private CharacterController characterController;
		[SerializeField] private float timeBetweenAttacks = 1f;
		[SerializeField] private CharacterAnimator animator;
		[SerializeField] private float reflectionMultiplier = 1f;
		
		public event Action OnStartAttack;
		public event Action OnReflectBullet;

		private bool _swordDisplayed;
		private Collider2D _collider;
		private RaycastHit2D[] _hits;
		private float _lastAttack;

		private void Awake()
		{
			_collider = GetComponent<Collider2D>();
			_hits = new RaycastHit2D[5];
			animator.OnAttackAnimation += MakeAttack;
		}

		public void Attack()
		{
			if (!CanAttack()) return;
			_lastAttack = Time.time;
			OnStartAttack?.Invoke();
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
			var bullet = hit.collider.GetComponent<Bullet>();
			if (bullet != null) ReflectBullet(bullet);
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

		private void ReflectBullet(Bullet bullet)
		{
			var bulletTransform = bullet.transform;
			var direction = (bulletTransform.position - transform.position).normalized;
			direction.y = bulletTransform.right.y;
			bullet.gameObject.layer = LayerMask.NameToLayer("Player");
			bullet.Damage *= reflectionMultiplier;
			bulletTransform.right = direction;
			OnReflectBullet?.Invoke();
		}
	}
}