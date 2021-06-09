using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
	public class SceneColorFader : SceneFader
	{
		[SerializeField] private Color color;
		[SerializeField] private Image overlay;

		protected override IEnumerator FadingInRoutine(float duration)
		{
			return FadingRoutine(1, 0, duration);
		}

		protected override IEnumerator FadingOutRoutine(float duration)
		{
			return FadingRoutine(0, 1, duration);
		}

		private IEnumerator FadingRoutine(float startAlpha, float finishAlpha, float duration)
		{
			var step = (finishAlpha - startAlpha) / duration;

			overlay.color = color;
			overlay.color = overlay.color.SetAlpha(startAlpha);
			
			while (!Math.HaveReachedValue(startAlpha, finishAlpha, overlay.color.a))
			{
				overlay.color = overlay.color.AddAlpha(step * Time.deltaTime);
				yield return null;
			}
			
			overlay.color = overlay.color.SetAlpha(finishAlpha);
		}
	}
}