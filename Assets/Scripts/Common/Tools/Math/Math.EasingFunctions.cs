using UnityEngine;

namespace Common
{
	public static partial class Math
	{
		public static float EaseInSine(float x)
		{
			return 1 - Mathf.Cos(x * Mathf.PI / 2f);
		}

		public static float EaseOutSine(float x)
		{
			return Mathf.Sin(x * Mathf.PI / 2f);
		}

		public static float EaseInQuad(float x)
		{
			return x * x;
		}
		
		public static float EaseOutQuad(float x)
		{
			return 1f - (1f - x) * (1f - x);
		}

		public static float EaseInCubic(float x)
		{
			return x * x * x;
		}
		
		public static float EaseOutCubic(float x)
		{
			return 1 - Mathf.Pow(1 - x, 3);
		}
	}
}