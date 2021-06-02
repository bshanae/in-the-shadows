using System;
using Common;
using UnityEngine;

using Object = UnityEngine.Object;

namespace Level
{
	public class FigureLoader : MonoBehaviour
	{
		private const string PrefabFolder = "Prefabs/Level/Figures";

		[SerializeField] private GameObject figureParent;

		public event Action FigureLoaded;

		private void Start()
		{
			TryInstantiatePrefab();			
		}

		private void TryInstantiatePrefab()
		{
			var prefab = Resources.Load<GameObject>($"{PrefabFolder}/{GetFigurePrefabName()}");

			if (prefab != null)
			{
				Instantiate<Object>(prefab, figureParent.transform);
				FigureLoaded?.Invoke();
			}
		}

		private static string GetFigurePrefabName()
		{
			try
			{
				var sceneSwitcher = Finder.FindMandatory<SceneSwitcher>();
				var meta = sceneSwitcher.MetaOfThisScene;
				var figurePrefabName = meta.GetField<string>("figure_prefab_name");

				return figurePrefabName;
			}
			catch (Finder.MandatoryObjectNotFound)
			{
				Debug.LogError("Scene switcher not found");
				return string.Empty;
			}
			catch (SceneMeta.CantGetField)
			{
				Debug.LogError("Figure prefab name meta not found");
				return string.Empty;
			}
		}
	}
}