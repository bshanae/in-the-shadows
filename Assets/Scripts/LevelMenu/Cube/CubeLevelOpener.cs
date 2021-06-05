using Common;
using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CubeLevelConfiguration))]
	public class CubeLevelOpener : MonoBehaviour
	{
		private string _figurePrefab;

		private void Awake()
		{
			_figurePrefab = GetComponent<CubeLevelConfiguration>().FigurePrefab;
		}
	
		public void OpenLevel()
		{
			if (!enabled)
				return;

			try
			{
				var sceneSwitcher = Finder.FindMandatory<SceneSwitcher>();

				sceneSwitcher.MetaOfNextScene.PutField("figure_prefab_name", _figurePrefab);
				sceneSwitcher.SwitchToScene("Level");
			}
			catch (Finder.MandatoryObjectNotFound)
			{
				Debug.LogError("Scene switcher not found");
			}
		}
	}
}