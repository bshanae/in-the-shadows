using Common;
using UnityEditor;

namespace Editor
{
	public static class PlayerProgressTools
	{
		private static PlayerProgress Instance => PlayerProgress.Instance;

		[MenuItem("Tools/Increment progress")]
		public static void IncrementProgress()
		{
			Instance.IncrementLevel();
			Instance.SetNewLevelAsCurrent();
		}

		[MenuItem("Tools/Reset progress")]
		public static void ResetProgress()
		{
			Instance.ResetProgress();
		}
	}
}