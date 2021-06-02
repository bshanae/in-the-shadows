using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
	public class SceneSwitcher : MonoBehaviour
	{
		[SerializeField] private float fadingDuration;

		private SceneFader[] _sceneFaders;

		public SceneMeta MetaOfThisScene { get; private set;  }
		public SceneMeta MetaOfNextScene { get; private set;  }

		private void Awake()
		{
			ProcessFaders();
			ProcessMetas();

			void ProcessFaders()
			{
				_sceneFaders = GetComponents<SceneFader>() ?? new SceneFader[] {};

				if (_sceneFaders.Length == 0)
					Debug.Log($"Scene faders are not used in {name}");
			}

			void ProcessMetas()
			{
				var courier = SceneMetaCourier.Instance;

				if (courier == null)
					return;

				MetaOfThisScene = courier.SceneMeta ?? new SceneMeta();
				MetaOfNextScene = courier.SceneMeta = new SceneMeta();
			}
		}

		private void Start()
		{
			RunCoroutines(FadingType.FadeIn);
		}

		public void SwitchToScene(string sceneName)
		{
			RunCoroutines(FadingType.FadeOut);
			WaitForFinish(() => SceneManager.LoadScene(sceneName));
		}

		private enum FadingType
		{
			FadeIn,
			FadeOut
		}

		private void RunCoroutines(FadingType type)
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

		private void WaitForFinish(Action onFinish)
		{
			StopAllCoroutines();
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