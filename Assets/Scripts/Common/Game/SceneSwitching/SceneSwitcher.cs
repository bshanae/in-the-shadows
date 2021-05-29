using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
	public class SceneSwitcher : MonoBehaviour
	{
		[SerializeField] private float fadingDuration;

		private SceneFader[] _sceneFaders;

		private void Awake()
		{
			_sceneFaders = GetComponents<SceneFader>() ?? new SceneFader[] { };

			if (_sceneFaders.Length == 0)
				Debug.Log($"Scene faders are not used in {name}");
		}

		private void Start()
		{
			StopAllCoroutines();
			StartCoroutine(RunCoroutines(FadingType.FadeIn));
		}

		[UsedImplicitly]
		public void SwitchToScene(string sceneName)
		{
			StopAllCoroutines();
			StartCoroutine(RunCoroutines(FadingType.FadeOut, () => SceneManager.LoadScene(sceneName)));
		}

		private enum FadingType
		{
			FadeIn,
			FadeOut
		}

		private IEnumerator RunCoroutines(FadingType type, Action onFinish = null)
		{
			foreach (var sceneFader in _sceneFaders)
			{
				switch (type)
				{
					case FadingType.FadeIn:
					{
						StartCoroutine(sceneFader.FadingInRoutine(fadingDuration));
						break;
					}

					case FadingType.FadeOut:
					{
						StartCoroutine(sceneFader.FadingOutRoutine(fadingDuration));
						break;
					}

					default:
						throw new ArgumentOutOfRangeException(nameof(type), type, null);
				}
			}

			yield return new WaitForSeconds(fadingDuration);
			onFinish?.Invoke();
		}
	}
}