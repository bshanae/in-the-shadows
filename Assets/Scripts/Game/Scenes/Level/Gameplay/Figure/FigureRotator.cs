using Common;
using UnityEngine;

namespace Level
{
	public class FigureRotator : MonoBehaviour
	{
		private bool _rotateHorizontally;
		private bool _rotateVertically;
		private bool _rotateAlternatively;

		public void Rotate(Vector2 value)
		{
			var rotation = value * LevelSettings.Instance.figureRotator.sensitivity;
			var cameraTransform = Finder.FindCamera().transform;

			if (_rotateHorizontally)
				transform.Rotate(Vector3.up, -1f * rotation.x, Space.World);

			if (_rotateVertically)
				transform.Rotate(cameraTransform.right, rotation.y, Space.World);
		}

		public void RotateAlternatively(float value)
		{
			if (_rotateAlternatively)
			{
				var rotation = value * LevelSettings.Instance.figureRotator.sensitivity;
				transform.Rotate(new Vector3(0, 0, 1), -1f * rotation, Space.World);
			}
		}

		private void Awake()
		{
			// Here I assume, that settings are loaded

			var settings = Finder.FindMandatory<LevelSettings>();

			_rotateHorizontally = settings.figureRotator.rotationMode >= FigureRotationMode.H;
			_rotateVertically = settings.figureRotator.rotationMode >= FigureRotationMode.HV;
			_rotateAlternatively = settings.figureRotator.rotationMode >= FigureRotationMode.HVA;
		}
	}
}