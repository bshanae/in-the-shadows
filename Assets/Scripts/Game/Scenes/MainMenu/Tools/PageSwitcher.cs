using System;
using System.Collections;
using UnityEngine;

namespace MainMenu
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
			from.canvasGroup.interactable = false;
			from.canvasGroup.blocksRaycasts = false;

			to.canvasGroup.alpha = 0;
			to.canvasGroup.interactable = true;
			to.canvasGroup.blocksRaycasts = true;

			yield return FadeCoroutine(to, 0, 1, fadeDuration);
		}

		private IEnumerator FadeCoroutine(Page page, float alphaStart, float alphaFinish, float duration)
		{
			var canvasGroup = page.GetComponent<CanvasGroup>();
			var alphaStep = (alphaFinish - alphaStart) / duration;

			canvasGroup.alpha = alphaStart;
			
			while(Mathf.Abs(canvasGroup.alpha - alphaFinish) > float.Epsilon)
			{
				canvasGroup.alpha += alphaStep * Time.deltaTime;
				yield return null;
			}

			canvasGroup.alpha = alphaFinish;
		}
	}
}