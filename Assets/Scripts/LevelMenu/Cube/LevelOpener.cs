using Common;
using UnityEngine;

namespace LevelMenu
{
	public class LevelOpener : MonoBehaviour
	{
		[SerializeField] private string figurePrefabName;
	
		public void OpenLevel()
		{
			try
			{
				var sceneSwitcher = Finder.FindMandatory<SceneSwitcher>();

				sceneSwitcher.MetaOfNextScene.PutField("figure_prefab_name", figurePrefabName);
				sceneSwitcher.SwitchToScene("Level");
			}
			catch (Finder.MandatoryObjectNotFound)
			{
				Debug.LogError("Scene switcher not found");
			}
		}
	}
}