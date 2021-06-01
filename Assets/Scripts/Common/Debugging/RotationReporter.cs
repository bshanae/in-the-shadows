using UnityEngine;

namespace Common.Debugging
{
	public class RotationReporter : MonoBehaviour
	{
		[SerializeField] private Vector3 globalRotation;
		[SerializeField] private Vector3 localRotation;

		private void Update()
		{
			var cachedTransform = transform;

			globalRotation = cachedTransform.rotation.eulerAngles;
			localRotation = cachedTransform.localRotation.eulerAngles;
		}
	}
}