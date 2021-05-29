using System.Collections;
using UnityEngine;

namespace Common
{
	public class SceneUIFader : MonoBehaviour, SceneFader
	{
		[SerializeField] private CanvasGroup rootCanvasGroup;

		public IEnumerator FadingInRoutine(float duration)
		{
			return FadingRoutine(0, 1, duration);
		}

		public IEnumerator FadingOutRoutine(float duration)
		{
			return FadingRoutine(1, 0, duration);
		}
		
		private IEnumerator FadingRoutine(float startAlpha, float finishAlpha, float duration)
		{
			var step = (finishAlpha - startAlpha) / duration;

			rootCanvasGroup.alpha = startAlpha;
			
			while (!Tools.HaveReachedValue(startAlpha, finishAlpha, rootCanvasGroup.alpha))
			{
				rootCanvasGroup.alpha += step * Time.deltaTime;
				yield return null;
			}
			
			rootCanvasGroup.alpha = finishAlpha;
		}
	}
}