using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Common
{
	[RequireComponent(typeof(Volume))]
	public class SceneVignetteFader : SceneFader
	{
		private Volume _vignetteVolume;

		private void Awake()
		{
			_vignetteVolume = GetComponent<Volume>();
		}

		protected override IEnumerator FadingInRoutine(float duration)
		{
			return FadingRoutine(1, 0, duration);
		}

		protected override IEnumerator FadingOutRoutine(float duration)
		{
			return FadingRoutine(0, 1, duration);
		}

		private IEnumerator FadingRoutine(float startIntensity, float finishIntensity, float duration)
		{
			var step = (finishIntensity - startIntensity) / duration;

			_vignetteVolume.weight = startIntensity;
			
			while (!MathTools.HaveReachedValue(startIntensity, finishIntensity, _vignetteVolume.weight))
			{
				_vignetteVolume.weight += step * Time.deltaTime;
				yield return null;
			}
			
			_vignetteVolume.weight = finishIntensity;
		}
	}
}