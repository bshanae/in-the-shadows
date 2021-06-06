using Common;
using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CubeLevelConfiguration))]
	[RequireComponent(typeof(CubeLevelOpener))]
	[RequireComponent(typeof(CubeCameraMover))]
	[RequireComponent(typeof(CubeHighlighter))]
	[RequireComponent(typeof(CubeLocker))]
	[RequireComponent(typeof(CubeRotator))]
	[RequireComponent(typeof(CubeRotationRestorer))]
	public class Cube : MonoBehaviour
	{
		private CubeLevelConfiguration _levelConfiguration;
		private CubeLevelOpener _levelOpener;
		private CubeCameraMover _cameraMover;
		private CubeHighlighter _highlighter;
		private CubeLocker _locker;
		private CubeRotator _rotator;
		private CubeRotationRestorer _rotationRestorer;

		private void Awake()
		{
			_levelConfiguration = GetComponent<CubeLevelConfiguration>();
			_levelOpener = GetComponent<CubeLevelOpener>();
			_cameraMover = GetComponent<CubeCameraMover>();
			_highlighter = GetComponent<CubeHighlighter>();
			_locker = GetComponent<CubeLocker>();
			_rotator = GetComponent<CubeRotator>();
			_rotationRestorer = GetComponent<CubeRotationRestorer>();

			Finder.FindMandatory<SceneSwitcher>().SceneOpened += OnSceneOpened;
		}

		private void Start()
		{
			if (_levelConfiguration.IsOpened && !_levelConfiguration.IsOpenedFirstTime)
				_locker.Unlock();
			else
				_locker.Lock();

			DisableComponents();
		}

		private void OnSceneOpened()
		{
			if (_levelConfiguration.IsOpened)
			{
				if (_levelConfiguration.IsOpenedFirstTime)	
					_locker.ShowUnlockingAnimation(EnableComponents);
				else
					EnableComponents();
			}
		}

		private void EnableComponents()
		{
			_levelOpener.enabled = true;
			_highlighter.enabled = true;
			_rotator.enabled = true;
			_rotationRestorer.enabled = true;
		}

		private void DisableComponents()
		{
			_levelOpener.enabled = false;
			_highlighter.enabled = false;
			_rotator.enabled = false;
			_rotationRestorer.enabled = false;
		}
	}
}