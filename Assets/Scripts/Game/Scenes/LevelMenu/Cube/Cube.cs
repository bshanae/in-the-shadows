using Common;
using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CubeLevelConfigurationHolder))]
	[RequireComponent(typeof(CubeLevelOpener))]
	[RequireComponent(typeof(CubeCameraMover))]
	[RequireComponent(typeof(CubeHighlighter))]
	[RequireComponent(typeof(CubeSoundPlayer))]
	[RequireComponent(typeof(CubeLocker))]
	[RequireComponent(typeof(CubeRotator))]
	[RequireComponent(typeof(CubeRotationRestorer))]
	public class Cube : MonoBehaviour
	{
		private CubeLevelConfigurationHolder _levelConfigurationHolder;
		private CubeLevelOpener _levelOpener;
		private CubeCameraMover _cameraMover;
		private CubeHighlighter _highlighter;
		private CubeSoundPlayer _soundPlayer;
		private CubeLocker _locker;
		private CubeRotator _rotator;
		private CubeRotationRestorer _rotationRestorer;

		private bool IsOpened
		{
			get
			{
				return _levelConfigurationHolder.LevelConfiguration.IsOpened;
			}
		}

		private bool ShowUnlockingAnimation
		{
			get
			{
				var configuration = _levelConfigurationHolder.LevelConfiguration;
				var showUnlockingAnimation = Finder.FindMandatory<LevelMenuMetaLoader>().ShowUnlockingAnimation;

				return configuration.IsOpened && configuration.IsNew && showUnlockingAnimation;
			}
		}

		private void Awake()
		{
			_levelConfigurationHolder = GetComponent<CubeLevelConfigurationHolder>();
			_levelOpener = GetComponent<CubeLevelOpener>();
			_cameraMover = GetComponent<CubeCameraMover>();
			_highlighter = GetComponent<CubeHighlighter>();
			_soundPlayer = GetComponent<CubeSoundPlayer>();
			_locker = GetComponent<CubeLocker>();
			_rotator = GetComponent<CubeRotator>();
			_rotationRestorer = GetComponent<CubeRotationRestorer>();

			Finder.FindMandatory<SceneSwitcher>().SceneOpened += OnSceneOpened;
		}

		private void Start()
		{
			if (IsOpened)
				_locker.Unlock();
			else
				_locker.Lock();

			DisableComponents();
		}

		private void OnSceneOpened()
		{
			if (IsOpened)
			{
				if (ShowUnlockingAnimation)
				{
					_locker.ShowUnlockingAnimation(EnableComponents);
					PlayerProgress.Instance.UnsetNewLevel();
				}
				else
				{
					EnableComponents();
				}
			}
		}

		private void EnableComponents()
		{
			_levelOpener.enabled = true;
			_highlighter.enabled = true;
			_soundPlayer.enabled = true;
			_rotator.enabled = true;
			_rotationRestorer.enabled = true;
		}

		private void DisableComponents()
		{
			_levelOpener.enabled = false;
			_highlighter.enabled = false;
			_soundPlayer.enabled = false;
			_rotator.enabled = false;
			_rotationRestorer.enabled = false;
		}
	}
}