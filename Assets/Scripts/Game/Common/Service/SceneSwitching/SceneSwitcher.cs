using System;
using System.Collections;
using System.Linq;
using Common.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
	public class SceneSwitcher : MonoBehaviour
	{
		[SerializeField] private float fadingDuration;

		private SceneFader[] _sceneFaders;
		private bool _isBusy;

		public event Action SceneOpened;

		private void Awake()
		{
			_sceneFaders = GetComponents<SceneFader>() ?? new SceneFader[] {};

			if (_sceneFaders.Length == 0)
				Debug.Log($"Scene faders are not used in {name}");
		}

		private void Start()
		{
			if (_isBusy)
				return;

			_isBusy = true;
			InputTools.DisableAllInput();

			StartFadingCoroutines(FadingType.FadeIn);
			WaitForFadingCoroutinesFinish(AfterFinish);

			void AfterFinish()
			{
				InputTools.EnableAllInput();
				_isBusy = false;
				SceneOpened?.Invoke();
			}
		}

		public void SwitchToScene(string sceneName, SceneMeta meta = null)
		{
			if (_isBusy)
				return;

			_isBusy = true;
			InputTools.DisableAllInput();

			StartFadingCoroutines(FadingType.FadeOut);
			WaitForFadingCoroutinesFinish(AfterFinish);

			void AfterFinish()
			{
				SceneMetaCourier.Instance.SceneMeta = meta;
				SceneManager.LoadScene(sceneName);
				_isBusy = false;
			}
		}

		private enum FadingType
		{
			FadeIn,
			FadeOut
		}

		private void StartFadingCoroutines(FadingType type)
		{
			switch (type)
			{
				case FadingType.FadeIn:
				{
					foreach (var sceneFader in _sceneFaders)
						sceneFader.FadeIn(GetDuration(sceneFader));

					break;
				}

				case FadingType.FadeOut:
				{
					foreach (var sceneFader in _sceneFaders)
						sceneFader.FadeOut(GetDuration(sceneFader));

					break;
				}

				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}

			float GetDuration(SceneFader sceneFader)
			{
				if (sceneFader.fadingDurationOverride != 0f)
					return sceneFader.fadingDurationOverride;

				return fadingDuration;
			}
		}

		private void WaitForFadingCoroutinesFinish(Action onFinish = null)
		{
			StartCoroutine(Routine());
		
			IEnumerator Routine()
			{
				while (_sceneFaders.Any(sceneFader => sceneFader.IsRunning))
					yield return null;

				onFinish?.Invoke();
			}
		}
	}
}