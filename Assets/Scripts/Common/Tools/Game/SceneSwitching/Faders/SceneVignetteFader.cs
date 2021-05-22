using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

namespace Common
{
	[RequireComponent(typeof(PostProcessVolume))]
	public class SceneVignetteFader : MonoBehaviour, SceneFader
	{
		[SerializeField] private float vignetteFadingDuration;

		private PostProcessVolume _volume;
		
		private void Awake()
		{
			_volume = GetComponent<PostProcessVolume>();
		}

		public void FadeIn(Action onFinished = null)
		{
			StartCoroutine(FadeCoroutine(1, 0, onFinished));
		}

		public void FadeOut(Action onFinished = null)
		{
			StartCoroutine(FadeCoroutine(0, 1, onFinished));
		}

		private IEnumerator FadeCoroutine(float startWeight, float finishWeight, Action onFinished)
		{
			yield return VignetteFadeCoroutine(startWeight, finishWeight);
			onFinished?.Invoke();
		}
		
		private IEnumerator VignetteFadeCoroutine(float startWeight, float finishWeight)
		{
			var sign = Mathf.Sign(finishWeight - startWeight);
			var step = (finishWeight - startWeight) / vignetteFadingDuration;

			_volume.weight = startWeight;
			
			while (!DidFinish())
			{
				_volume.weight += step * Time.deltaTime;
				yield return null;
			}
			
			_volume.weight = finishWeight;

			bool DidFinish()
			{
				return sign > 0f ? _volume.weight >= finishWeight : _volume.weight <= finishWeight;
			}
		}
	}
}