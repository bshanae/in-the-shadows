using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CameraToCubeMover))]
	public class LevelNamePoint : MonoBehaviour
	{
		[SerializeField] private string levelName;

		public string LevelName => levelName;
		public Vector3 Point => transform.position;
	}
}