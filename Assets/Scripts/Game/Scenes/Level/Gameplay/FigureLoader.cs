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
			var name = Finder.FindMandatory<LevelMetaLoader>().FigurePrefab;
			var prefab = Resources.Load<GameObject>($"{PrefabFolder}/{name}");

			if (prefab != null)
			{
				Instantiate<Object>(prefab, figureParent.transform);
				FigureLoaded?.Invoke();
			}
			else
			{
				Debug.LogError($"Prefab {name} not found!");
				FigureLoaded?.Invoke();
			}
		}
	}
}