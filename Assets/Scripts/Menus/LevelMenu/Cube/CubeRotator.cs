using Common;
using UnityEngine;

namespace LevelMenu
{
	public class CubeRotator : MonoBehaviour
	{
		public void TryRotateBy(Vector2 rotation)
		{
			rotation = ApplySensitivity(rotation);

			var cameraTransform = Finder.FindCamera().transform;

			transform.Rotate(cameraTransform.up, -1f * rotation.x, Space.World);
			transform.Rotate(cameraTransform.right, rotation.y, Space.World);
		}

		public bool IsImportant(Vector2 rotation)
		{
			rotation = ApplySensitivity(rotation);

			var threshold = Settings.Instance.cubeRotator.importanceThreshold;
			return Mathf.Abs(rotation.x) > threshold && Mathf.Abs(rotation.y) > threshold;
		}

		private static Vector2 ApplySensitivity(Vector2 rotation)
		{
			return rotation * Settings.Instance.cubeRotator.sensitivity;
		}
	}
}