using TMPro;
using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CameraMover))]
	public class LevelNameResolver : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI levelName;

		private CameraMover _cameraMover;
		private LevelNamePoint[] _levelNamePoints;

		private Vector3 Point => transform.position;

		private void Awake()
		{
			_cameraMover = GetComponent<CameraMover>();
			_levelNamePoints = FindObjectsOfType<LevelNamePoint>();
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
			LevelNamePoint closestPoint = null;

			foreach (var levelNamePoint in _levelNamePoints)
			{
				var newDistance = Vector3.Distance(this.Point, levelNamePoint.Point);

				if (newDistance < minDistance)
				{
					minDistance = newDistance;
					closestPoint = levelNamePoint;
				}
			}

			return closestPoint != null ? closestPoint.LevelName : "-";
		}
	}
}