using Common;
using UnityEngine;

namespace LevelMenu
{
	public class CubeLevelOpener : MonoBehaviour
	{
		public void OpenLevel()
		{
			Finder.FindSceneSwitcher().SwitchToScene("Level");
		}
	}
}