using Common;
using JetBrains.Annotations;
using UnityEngine;

namespace MainMenu
{
	public class MainPage : Page
	{
		[SerializeReference] private Page settingsPage;

		[UsedImplicitly]
		public void PlayButtonPressed()
		{
			try
			{
				Finder.FindMandatory<SceneSwitcher>().SwitchToScene("LevelMenu");
			}
			catch (Finder.MandatoryObjectNotFound)
			{
				Debug.LogError("Can't find scene switcher!");
			}
		}

		[UsedImplicitly]
		public void SettingsButtonPressed()
		{
			PageSwitcher.Instance.Switch(this, settingsPage);
		}

		[UsedImplicitly]
		public void ExitButtonPressed()
		{
			Application.Quit();
		}
	}
}