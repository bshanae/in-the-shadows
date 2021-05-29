using UnityEngine;

namespace Common
{
	public static class ColorExtensions
	{
		public static Color SetAlpha(this Color color, float value)
		{
			color.a = value;
			return color;
		}

		public static Color AddAlpha(this Color color, float value)
		{
			color.a += value;
			return color;
		}
	}
}