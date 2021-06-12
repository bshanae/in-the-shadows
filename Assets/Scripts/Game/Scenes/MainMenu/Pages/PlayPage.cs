using Common;
using JetBrains.Annotations;
using UnityEngine;

namespace MainMenu
{
	public class PlayPage : Page
	{
		[UsedImplicitly]
		public void StoryModeButtonPressed()
		{
			OpenLevelMenu(false);
		}

		[UsedImplicitly]
		public void TestModeButtonPressed()
		{
			OpenLevelMenu(true);
		}

		[UsedImplicitly]
		public void ResetProgressButtonPressed()
		{
			PlayerProgress.Instance.ResetProgress();
		}

		private static void OpenLevelMenu(bool testMode)
		{
			try
			{
				var meta = new SceneMeta();
				meta.PutField("test_mode", testMode);
				
				Finder.FindMandatory<SceneSwitcher>().SwitchToScene("LevelMenu", meta);
			}
			catch (Finder.MandatoryObjectNotFound)
			{
				Debug.LogError("Can't find scene switcher!");
			}
		}
	}
}