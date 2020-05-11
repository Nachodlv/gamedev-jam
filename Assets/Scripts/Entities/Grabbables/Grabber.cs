using UnityEngine;
using Utils;

namespace Entities.Grabbables
{
	public class Grabber : MonoBehaviour
	{
		[SerializeField] private float grabbingDistance;
			
		private DistanceDetector _distanceDetector;
		private void Awake()
		{
			_distanceDetector = gameObject.AddComponent<DistanceDetector>();
			_distanceDetector.targetTag = "Grabbable";
			_distanceDetector.DetectionDistance = grabbingDistance;

			_distanceDetector.OnColliderInsideRadius += ColliderNear;
		}

		private void ColliderNear(Collider2D collider)
		{
			var grabbable = collider.GetComponentInParent<Grabbable>();
			if (grabbable == null) return;
			grabbable.OnGrabberNear(this);
		}
	}
}