using Common;

namespace LevelMenu
{
	public class LevelMenuMetaLoader : SceneMetaLoader
	{
		private bool _showUnlockingAnimation;

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

			_showUnlockingAnimation = meta.GetFieldOrDefault<bool>("show_unlocking_animation") is true;
		}
	}
}