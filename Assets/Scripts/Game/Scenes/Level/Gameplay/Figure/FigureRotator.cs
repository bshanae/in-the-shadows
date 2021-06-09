using Common;
using UnityEngine;

namespace Level
{
	public class FigureRotator : MonoBehaviour
	{
		public void Rotate(Vector2 value)
		{
			var rotation = value * LevelSettings.Instance.figureRotator.sensitivity;
			var cameraTransform = Finder.FindCamera().transform;
			
			transform.Rotate(cameraTransform.up, -1f * rotation.x, Space.World);
			transform.Rotate(cameraTransform.right, rotation.y, Space.World);
		}

		public void RotateAlternatively(float value)
		{
			var rotation = value * LevelSettings.Instance.figureRotator.sensitivity;
			transform.Rotate(new Vector3(0, 0, 1), -1f * rotation, Space.World);
		}
	}
}