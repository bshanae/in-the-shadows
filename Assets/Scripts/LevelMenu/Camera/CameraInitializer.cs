using System.Linq;
using Common;
using UnityEngine;

namespace LevelMenu
{
	public class CameraInitializer : MonoBehaviour
	{
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

			transform.position = transform.position.SetZ(currentLevel.transform.position.z);
		}
	}
}