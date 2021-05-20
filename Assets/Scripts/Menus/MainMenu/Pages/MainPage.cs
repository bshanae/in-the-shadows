using JetBrains.Annotations;
using UnityEngine;

namespace MainMenu
{
	public class MainPage : Page
	{
		[SerializeReference] private Page settingsPage;

		[UsedImplicitly]
		private void PlayButtonPressed()
		{
			
		}

		[UsedImplicitly]
		private void SettingsButtonPressed()
		{
			PageSwitcher.Instance.Switch(this, settingsPage);
		}

		[UsedImplicitly]
		private void ExitButtonPressed()
		{
			Application.Quit();
		}
	}
}