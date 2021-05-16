using System;
using System.Collections;
using UnityEngine;

namespace Menu
{
	public class PageSwitcher : MonoBehaviour
	{
		public static PageSwitcher Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
		}

		public void Switch(Page from, Page to)
		{
			StartCoroutine(SwitchCoroutine(from, to));
		}

		private IEnumerator SwitchCoroutine(Page from, Page to)
		{
			const float fadeDuration = 0.25f;

			yield return FadeCoroutine(from, 1, 0, fadeDuration);
			from.gameObject.SetActive(false);
			
			to.gameObject.SetActive(true);
			to.GetComponent<CanvasGroup>().alpha = 0;

			yield return FadeCoroutine(to, 0, 1, fadeDuration);
		}

		private IEnumerator FadeCoroutine(Page page, float alphaStart, float alphaFinish, float duration)
		{
			const float threshold = 0.001f;

			var canvasGroup = page.GetComponent<CanvasGroup>();
			var alphaStep = (alphaFinish - alphaStart) / duration;

			canvasGroup.alpha = alphaStart;
			
			while(Mathf.Abs(canvasGroup.alpha - alphaFinish) > threshold)
			{
				canvasGroup.alpha += alphaStep * Time.deltaTime;
				yield return null;
			}

			canvasGroup.alpha = alphaFinish;
		}
	}
}