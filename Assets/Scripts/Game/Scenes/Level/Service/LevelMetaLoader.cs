using Common;

namespace Level
{
	public class LevelMetaLoader : SceneMetaLoader
	{
		private int _levelIndex;

		public int LevelIndex
		{
			get
			{
				VerifyThatLoaded();
				return _levelIndex;
			}
		}

		protected override void LoadMeta(SceneMeta meta)
		{
			if (meta == null)
				return;

			_levelIndex = meta.GetField<int>("level_index");
		}
	}
}