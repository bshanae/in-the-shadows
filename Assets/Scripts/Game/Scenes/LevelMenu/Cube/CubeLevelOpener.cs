using Common;
using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CubeLevelConfigurationHolder))]
	public class CubeLevelOpener : MonoBehaviour
	{
		private int _levelIndex;
		private string _figurePrefab;

		private void Awake()
		{
			var levelConfigurationHolder = GetComponent<CubeLevelConfigurationHolder>();
			var levelConfiguration = levelConfigurationHolder.LevelConfiguration;

			_levelIndex = levelConfiguration.LevelIndex;
			_figurePrefab = levelConfiguration.FigurePrefab;
		}
	
		public void OpenLevel()
		{
			if (!enabled)
				return;

			try
			{
				var sceneSwitcher = Finder.FindMandatory<SceneSwitcher>();
				var sceneMeta = new SceneMeta();

				sceneMeta.PutField("level_index", _levelIndex);
				sceneMeta.PutField("figure_prefab", _figurePrefab);

				sceneSwitcher.SwitchToScene("Level", sceneMeta);
			}
			catch (Finder.MandatoryObjectNotFound)
			{
				Debug.LogError("Scene switcher not found");
			}
		}
	}
}