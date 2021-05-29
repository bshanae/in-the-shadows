using Common;
using UnityEngine;

namespace Game
{
	public class FigureRotator : MonoBehaviour
	{
		public void Rotate(Vector2 value)
		{
			var rotation = value * Settings.Instance.figureRotator.sensitivity;
			var cameraTransform = Finder.FindCamera().transform;

			transform.Rotate(cameraTransform.up, -1f * rotation.x, Space.World);
			transform.Rotate(cameraTransform.right, rotation.y, Space.World);
		}

		public void RotateAlternatively(float value)
		{
			transform.Rotate(new Vector3(1, 0, 0), -1f * value, Space.World);
		}
	}
}