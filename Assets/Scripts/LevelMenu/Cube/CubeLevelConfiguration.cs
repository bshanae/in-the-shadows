using UnityEngine;

namespace LevelMenu
{
	public class CubeLevelConfiguration : MonoBehaviour
	{
		[SerializeField] private string levelName;
		[SerializeField] private string figurePrefab;

		public string LevelName => levelName;
		public string FigurePrefab => figurePrefab;

		public bool IsOpened => figurePrefab != "Globe";
		public bool IsOpenedFirstTime => figurePrefab == "42";

		public Vector3 Position => transform.position;
	}
}