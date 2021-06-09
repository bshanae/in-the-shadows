using UnityEngine;

namespace Common
{
	public static class MaterialExtensions
	{
		private static readonly int BaseColorProperty = Shader.PropertyToID("_BaseColor");
		private static readonly int EmissiveColorProperty = Shader.PropertyToID("_EmissiveColor");

		public static Color GetBaseColor(this Material material)
		{
			return material.GetColor(BaseColorProperty);
		}

		public static void SetBaseColor(this Material material, Color color)
		{
			material.SetColor(BaseColorProperty, color);
		}

		public static Color GetEmissiveColor(this Material material)
		{
			return material.GetColor(EmissiveColorProperty);
		}

		public static void SetEmissiveColor(this Material material, Color color)
		{
			material.SetColor(EmissiveColorProperty, color);
		}
	}
}