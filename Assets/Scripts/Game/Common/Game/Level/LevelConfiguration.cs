using UnityEngine;

namespace Common
{
	[CreateAssetMenu(fileName = "Level", menuName = "Level configuration", order = 1)]
	public class LevelConfiguration : ScriptableObject
	{
		[SerializeField] private int levelIndex;
		[SerializeField] private string levelName;
		[SerializeField] private string figurePrefab;

		public int LevelIndex => levelIndex;
		public string LevelName => levelName;
		public string FigurePrefab => figurePrefab;

		public bool IsOpened => PlayerProgress.Instance.CurrentLevelIndex >= levelIndex;
		public bool IsNew => PlayerProgress.Instance.NewLevelIndex == levelIndex;
	}
}