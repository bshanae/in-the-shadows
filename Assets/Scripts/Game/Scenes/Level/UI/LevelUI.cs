using Common;
using Common.UI;
using JetBrains.Annotations;
using UnityEngine;

namespace Level
{
	public class LevelUI : MonoBehaviour
	{
		[SerializeField] private ButtonLockableFeature nextLevelButton;

		private int _thisLevelIndex;

		private void Start()
		{
			_thisLevelIndex = Finder.FindMandatory<LevelMetaLoader>().LevelIndex;

			Finder.FindMandatory<LevelSolver>().LevelSolved += UpdateUI;
			UpdateUI();
		}

		[UsedImplicitly]
		public void GoToMainMenuPressed()
		{
			Finder.FindMandatory<SceneSwitcher>().SwitchToScene("LevelMenu");
		}

		[UsedImplicitly]
		public void GoToNextLevelPressed()
		{
			var sceneMeta = new SceneMeta();
			sceneMeta.PutField("show_unlocking_animation", true);
			
			Finder.FindMandatory<SceneSwitcher>().SwitchToScene("LevelMenu", sceneMeta);
		}

		private void UpdateUI()
		{
			var currentLevelIndex = PlayerProgress.Instance.CurrentLevelIndex;
			var nextLevelIndex = _thisLevelIndex + 1;

			nextLevelButton.IsLocked = currentLevelIndex < nextLevelIndex;
		}
	}
}