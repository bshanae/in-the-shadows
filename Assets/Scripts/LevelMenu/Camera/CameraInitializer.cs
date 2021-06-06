using System.Linq;
using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CameraMover))]
	public class CameraInitializer : MonoBehaviour
	{
		private CameraMover _cameraMover;

		private void Awake()
		{
			_cameraMover = GetComponent<CameraMover>();
		}

		private void Start()
		{
			var allLevels = FindObjectsOfType<CubeLevelConfiguration>();

			var newLevel = allLevels.FirstOrDefault(level => level.IsOpenedFirstTime);
			var lastLevel = allLevels.FirstOrDefault(level => level.IsOpened);

			var currentLevel = newLevel != null ? newLevel : lastLevel;
			if (currentLevel == null)
			{
				Debug.LogError("Can't find current level");
				return;
			}

			_cameraMover.MoveImmediatelyTo(currentLevel.transform.position.z);
		}
	}
}