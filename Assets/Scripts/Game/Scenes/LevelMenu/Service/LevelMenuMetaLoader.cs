using Common;

namespace LevelMenu
{
	public class LevelMenuMetaLoader : SceneMetaLoader
	{
		private bool _testMode;
		private bool _showUnlockingAnimation;

		public bool TestMode
		{
			get
			{
				VerifyThatLoaded();
				return _testMode;
			}
		}

		public bool ShowUnlockingAnimation
		{
			get
			{
				VerifyThatLoaded();
				return _showUnlockingAnimation;
			}
		}

		protected override void LoadMeta(SceneMeta meta)
		{
			if (meta == null)
				return;

			_testMode = meta.GetFieldOrDefault<bool>("test_mode") is true;
			_showUnlockingAnimation = meta.GetFieldOrDefault<bool>("show_unlocking_animation") is true;
		}
	}
}