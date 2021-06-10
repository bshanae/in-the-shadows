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
			var levelConfiguration = Finder.FindMandatory<LevelConfigurator>().levelConfiguration;
			var prefab = Resources.Load<GameObject>($"{PrefabFolder}/{levelConfiguration.FigurePrefab}");

			if (prefab != null)
			{
				Instantiate<Object>(prefab, figureParent.transform);
				FigureLoaded?.Invoke();
			}
			else
			{
				Debug.LogError($"Prefab '{levelConfiguration.FigurePrefab}' not found!");
				FigureLoaded?.Invoke();
			}
		}
	}
}