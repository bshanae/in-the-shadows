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
			var allLevels = FindObjectsOfType<CubeLevelConfigurationHolder>();
			var allLevelSorted = allLevels.OrderBy(level => level.Position.z).ToArray();

			var newLevel = allLevelSorted.LastOrDefault(level => level.LevelConfiguration.IsNew);
			var lastLevel = allLevelSorted.LastOrDefault(level => level.LevelConfiguration.IsOpened);
			
			var currentLevel = newLevel != null ? newLevel : lastLevel;

			if (currentLevel == null)
			{
				Debug.LogError("Can't find current level");
				return;
			}
			
			_cameraMover.MoveImmediatelyTo(currentLevel.Position.z);
		}
	}
}