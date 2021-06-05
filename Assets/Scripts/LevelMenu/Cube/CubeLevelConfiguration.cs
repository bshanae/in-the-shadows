using UnityEngine;

namespace LevelMenu
{
	public class CubeLevelConfiguration : MonoBehaviour
	{
		[SerializeField] private string levelName;
		[SerializeField] private string figurePrefab;

		public string LevelName => levelName;
		public string FigurePrefab => figurePrefab;

		public bool IsOpen => true;
		public bool WasJustOpened => true;

		public Vector3 Position => transform.position;
	}
}