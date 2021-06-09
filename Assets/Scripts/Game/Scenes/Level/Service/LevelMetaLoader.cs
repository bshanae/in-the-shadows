using Common;

namespace Level
{
	public class LevelMetaLoader : SceneMetaLoader
	{
		private string _figurePrefab;
		private int _levelIndex;

		public string FigurePrefab
		{
			get
			{
				VerifyThatLoaded();
				return _figurePrefab;
			}
		}

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

			_figurePrefab = meta.GetField<string>("figure_prefab");
			_levelIndex = meta.GetField<int>("level_index");
		}
	}
}