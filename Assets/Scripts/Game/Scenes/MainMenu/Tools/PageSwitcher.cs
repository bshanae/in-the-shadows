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

			from.IsEnabled = false;
			yield return FadeCoroutine(from, 1, 0, fadeDuration);

			yield return FadeCoroutine(to, 0, 1, fadeDuration);
			to.IsEnabled = true;
		}

		private IEnumerator FadeCoroutine(Page page, float alphaStart, float alphaFinish, float duration)
		{
			var alphaStep = (alphaFinish - alphaStart) / duration;

			page.Alpha = alphaStart;
			
			while(Mathf.Abs(page.Alpha - alphaFinish) > float.Epsilon)
			{
				page.Alpha += alphaStep * Time.deltaTime;
				yield return null;
			}

			page.Alpha = alphaFinish;
		}
	}
}