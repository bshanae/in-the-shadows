using System;
using System.Collections;
using UnityEngine;

namespace Common
{
	public static class Routines
	{
		public static IEnumerator MaterialBaseColorLerp(
			Material material,
			Color targetColor,
			float duration,
			Func<float, float> easingFunction = null)
		{
			return MaterialColorLerp(
				material.GetBaseColor,
				material.SetBaseColor,
				targetColor,
				duration,
				easingFunction);
		}

		public static IEnumerator MaterialEmissiveColorLerp(
			Material material,
			Color targetColor,
			float duration,
			Func<float, float> easingFunction = null)
		{
			return MaterialColorLerp(
				material.GetEmissiveColor,
				material.SetEmissiveColor,
				targetColor,
				duration,
				easingFunction);
		}

		private static IEnumerator MaterialColorLerp(
			Func<Color> colorGetter,
			Action<Color> colorSetter,
			Color targetColor,
			float duration,
			Func<float, float> easingFunction)
		{
			var startColor = colorGetter();
			var timeLeft = duration;

			while (timeLeft > 0f)
			{
				timeLeft -= Time.deltaTime;

				var progress = Mathf.Clamp01(1f - timeLeft / duration);
				var easedProgress = easingFunction?.Invoke(progress) ?? progress;

				var color = Color.LerpUnclamped(startColor, targetColor, easedProgress);
				colorSetter(color);

				yield return null;
			}
		}
	}
}