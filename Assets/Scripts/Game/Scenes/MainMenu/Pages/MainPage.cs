using Common;
using JetBrains.Annotations;
using UnityEngine;

namespace MainMenu
{
	public class MainPage : Page
	{
		[SerializeReference] private Page playPage;
		[SerializeReference] private Page settingsPage;

		[UsedImplicitly]
		public void PlayButtonPressed()
		{
			PageSwitcher.Instance.Switch(this, playPage);
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