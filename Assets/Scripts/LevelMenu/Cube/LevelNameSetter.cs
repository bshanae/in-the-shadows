using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CameraToCubeMover))]
	public class LevelNameSetter : MonoBehaviour
	{
		[SerializeField] private string levelName;

		private CameraToCubeMover _cameraToCubeMover;

		private void Awake()
		{
			_cameraToCubeMover = GetComponent<CameraToCubeMover>();
		}

		private void Update()
		{
			if (!_cameraToCubeMover.ShouldMoveCamera())
			{
				SetNameIfNeeded();
			}
		}
		
		private void SetNameIfNeeded()
		{
			var text = LevelMenuSettings.Instance.levelNameSetter.levelName;

			if (text.text != levelName)
				text.text = levelName;
		}
	}
}