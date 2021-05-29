using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace Common
{
	[RequireComponent(typeof(Volume))]
	public class SceneVignetteFader : MonoBehaviour, SceneFader
	{
		private Vignette _vignette;

		private void Awake()
		{
			var volume = GetComponent<Volume>();

			if (!volume.profile.TryGet(out _vignette))
				throw new Exception("Vignette component not found in Volume profile");
		}

		public IEnumerator FadingInRoutine(float duration)
		{
			return FadingRoutine(1, 0, duration);
		}

		public IEnumerator FadingOutRoutine(float duration)
		{
			return FadingRoutine(0, 1, duration);
		}

		private IEnumerator FadingRoutine(float startIntensity, float finishIntensity, float duration)
		{
			var step = (finishIntensity - startIntensity) / duration;

			_vignette.intensity.value = startIntensity;
			
			while (!Tools.HaveReachedValue(startIntensity, finishIntensity, _vignette.intensity.value))
			{
				_vignette.intensity.value += step * Time.deltaTime;
				yield return null;
			}
			
			_vignette.intensity.value = finishIntensity;
		}
	}
}