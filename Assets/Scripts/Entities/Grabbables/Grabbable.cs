using System;
using System.Collections;
using UnityEngine;

namespace Entities.Grabbables
{
	public abstract class Grabbable: Pooleable
	{
		[SerializeField] private Animator animator;
		[SerializeField] private float speed;
		[SerializeField] private float maxSpeed;
		
		private Vector3 _velocity = Vector3.zero;
		private const float _smoothSpeed = 0.5f;
		private bool _goingToTarget;
		private Func<Grabber, IEnumerator> _goToTargetFunction;
		private static readonly int Idle = Animator.StringToHash("idle");

		private void Awake()
		{
			_goToTargetFunction = GoToTarget;
		}

		protected abstract void Grabbed(Grabber grabber);

		public void OnGrabberNear(Grabber grabber)
		{
			if (_goingToTarget) return;
			_goingToTarget = true;
			StartCoroutine(_goToTargetFunction(grabber));
		}

		public override void Activate()
		{
			base.Activate();
			animator.SetBool(Idle, true);
		}

		private IEnumerator GoToTarget(Grabber target)
		{
			var grabberTransform = target.transform;
			while (Vector3.Distance(transform.position, grabberTransform.position) > 0.01f)
			{
				var currentPosition = transform.position;
				transform.position = Vector3.SmoothDamp(currentPosition, grabberTransform.position, ref _velocity, _smoothSpeed, speed);
				yield return null;
			}
			ReachedGrabber(target);
		}

		private void ReachedGrabber(Grabber target)
		{
			Grabbed(target);
			animator.SetBool(Idle, false);
			Deactivate();
		}
	}
}