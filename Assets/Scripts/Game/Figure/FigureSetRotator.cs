using UnityEngine;

namespace Game
{
	public class FigureSetRotator : MonoBehaviour
	{
		public void Rotate(float value)
		{
			var rotation = value * LevelSettings.Instance.figureSetRotator.sensitivity;
			transform.Rotate(new Vector3(0, 0, 1), -1f * rotation, Space.World);
		}
	}
}