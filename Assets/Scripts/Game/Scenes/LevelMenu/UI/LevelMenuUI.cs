using Common;
using JetBrains.Annotations;
using UnityEngine;

namespace LevelMenu
{
	public class LevelMenuUI : MonoBehaviour
	{
		[UsedImplicitly]
		public void GoToMainMenu()
		{
			Finder.FindMandatory<SceneSwitcher>().SwitchToScene("MainMenu");
		}
	}
}