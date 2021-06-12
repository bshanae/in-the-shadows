using Common;
using TMPro;
using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CameraMover))]
	public class LevelNameResolver : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI levelName;

		private CameraMover _cameraMover;
		private CubeLevelConfigurationHolder[] _levelConfigurations;

		private Vector3 Position => transform.position;

		private void Awake()
		{
			_cameraMover = GetComponent<CameraMover>();
			_levelConfigurations = FindObjectsOfType<CubeLevelConfigurationHolder>();
		}

		private void Start()
		{
			UpdateLevelName();
			_cameraMover.Moved += UpdateLevelName;
		}

		private void OnDestroy()
		{
			_cameraMover.Moved -= UpdateLevelName;
		}

		private void UpdateLevelName()
		{
			levelName.text = FindCurrentLevelName();
		}

		private string FindCurrentLevelName()
		{
			var minDistance = float.MaxValue;
			CubeLevelConfigurationHolder closestLevel = null;

			foreach (var levelNamePoint in _levelConfigurations)
			{
				var newDistance = Vector3.Distance(this.Position, levelNamePoint.Position);

				if (newDistance < minDistance)
				{
					minDistance = newDistance;
					closestLevel = levelNamePoint;
				}
			}

			return CanShowNameOrLevel(closestLevel) ? closestLevel.LevelConfiguration.LevelName : "?";

			static bool CanShowNameOrLevel(CubeLevelConfigurationHolder levelHolder)
			{
				if (levelHolder == null)
					return false;

				var testMode = Finder.Find<LevelMenuMetaLoader>().TestMode;
				var isOpened = levelHolder.LevelConfiguration.IsOpened;

				return testMode || isOpened;
			}
		}
	}
}