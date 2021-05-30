using Common;
using UnityEngine;

namespace LevelMenu
{
	public class LevelOpener : MonoBehaviour
	{
		public void OpenLevel()
		{
			Finder.FindSceneSwitcher().SwitchToScene("Level");
		}
	}
}