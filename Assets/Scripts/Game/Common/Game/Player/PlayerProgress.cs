using UnityEngine;

namespace Common
{
	public class PlayerProgress
	{
		private static PlayerProgress _instance;

		public static PlayerProgress Instance => _instance ??= new PlayerProgress();

		private static class Key
		{
			public const string CurrentLevelIndex = "current_level_index";
			public const string NewLevelIndex = "new_level_index";	
		}

		private const int NumberOfLevels = 6;

		public int CurrentLevelIndex { get; private set; }
		public int? NewLevelIndex { get; private set; }

		public void IncrementLevel()
		{
			CurrentLevelIndex = Mathf.Min(CurrentLevelIndex + 1, NumberOfLevels);
			SaveProgress();
		}

		public void SetNewLevelAsCurrent()
		{
			NewLevelIndex = CurrentLevelIndex;
			SaveProgress();
		}

		public void UnsetNewLevel()
		{
			NewLevelIndex = null;
			SaveProgress();
		}

		public void ResetProgress()
		{
			CurrentLevelIndex = 0;
			NewLevelIndex = 0;
		
			SaveProgress();
		}

		private PlayerProgress()
		{
			LoadProgress();
		}

		private void LoadProgress()
		{
			if (PlayerPrefs.HasKey(Key.CurrentLevelIndex))
				CurrentLevelIndex = PlayerPrefs.GetInt(Key.CurrentLevelIndex);
			else
				CurrentLevelIndex = 0;

			if (PlayerPrefs.HasKey(Key.NewLevelIndex))
				NewLevelIndex = PlayerPrefs.GetInt(Key.NewLevelIndex);
			else
				NewLevelIndex = 0;
		}

		private void SaveProgress()
		{
			PlayerPrefs.SetInt(Key.CurrentLevelIndex, CurrentLevelIndex);
			PlayerPrefs.SetInt(Key.NewLevelIndex, NewLevelIndex ?? -1);
		}
	}
}