using System;
using System.Collections;
using UnityEngine;

namespace Entities.Grabbables
{
	[RequireComponent(typeof(Rigidbody2D))]
	public abstract class Grabbable: Pooleable
	{
		private const float SmoothSpeed = 0.5f;

		[SerializeField] private Animator animator;
		[SerializeField] private float speed;
		[SerializeField] private float maxSpeed;
		
		public Rigidbody2D Rigidbody2D => _rigidbody2D;

		private Rigidbody2D _rigidbody2D;
		private Vector3 _velocity = Vector3.zero;
		private bool _goingToTarget;
		private bool _reachedTarget;
		private Func<Grabber, IEnumerator> _goToTargetFunction;
		private static readonly int Idle = Animator.StringToHash("idle");
		private Grabber _grabber;

		protected void Awake()
		{
			_goToTargetFunction = GoToTarget;
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		protected abstract void Grabbed(Grabber grabber);

		public void OnGrabberNear(Grabber grabber)
		{
			if (_goingToTarget) return;
			_goingToTarget = true;
			_grabber = grabber;
			StartCoroutine(_goToTargetFunction(grabber));
		}

		public override void Activate()
		{
			base.Activate();
			_rigidbody2D.isKinematic = false;
		}

		private IEnumerator GoToTarget(Grabber target)
		{
			var grabberTransform = target.transform;
			_reachedTarget = false;
			while (!_reachedTarget)
			{
				var currentPosition = transform.position;
				transform.position = Vector3.SmoothDamp(currentPosition, grabberTransform.position, ref _velocity, SmoothSpeed, speed);
				yield return null;
			}
		}

		private void ReachedGrabber()
		{
			Grabbed(_grabber);
			animator.SetBool(Idle, false);
			Deactivate();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Player") && _goingToTarget)
			{
				_reachedTarget = true;
				_goingToTarget = false;
				ReachedGrabber();
			}
			else if (other.CompareTag("Floor"))
			{
				_rigidbody2D.isKinematic = true;
				var position = _rigidbody2D.position;
				position.y += 0.3f;
				_rigidbody2D.position = position;
				animator.SetBool(Idle, true);
				_rigidbody2D.velocity = Vector2.zero;
			}
		}
	}
}