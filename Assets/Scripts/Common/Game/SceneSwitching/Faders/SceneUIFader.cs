using System.Collections;
using UnityEngine;

namespace Common
{
	public class SceneUIFader : SceneFader
	{
		[SerializeField] private CanvasGroup rootCanvasGroup;

		protected override IEnumerator FadingInRoutine(float duration)
		{
			return FadingRoutine(0, 1, duration);
		}

		protected override IEnumerator FadingOutRoutine(float duration)
		{
			return FadingRoutine(1, 0, duration);
		}
		
		private IEnumerator FadingRoutine(float startAlpha, float finishAlpha, float duration)
		{
			var step = (finishAlpha - startAlpha) / duration;

			rootCanvasGroup.alpha = startAlpha;
			
			while (!MathTools.HaveReachedValue(startAlpha, finishAlpha, rootCanvasGroup.alpha))
			{
				rootCanvasGroup.alpha += step * Time.deltaTime;
				yield return null;
			}
			
			rootCanvasGroup.alpha = finishAlpha;
		}
	}
}