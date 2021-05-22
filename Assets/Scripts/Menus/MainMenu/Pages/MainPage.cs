using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
	public class MainPage : Page
	{
		[SerializeReference] private Page settingsPage;

		[UsedImplicitly]
		private void PlayButtonPressed()
		{
			SceneManager.LoadScene("LevelMenu");
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