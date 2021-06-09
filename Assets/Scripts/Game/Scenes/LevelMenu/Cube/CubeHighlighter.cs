using System.Collections;
using Common;
using UnityEngine;

namespace LevelMenu
{
	public class CubeHighlighter : MonoBehaviour
	{
		private static readonly int EmissiveColorProperty = Shader.PropertyToID("_EmissiveColor");

		private Material _material;
		private Color _originalEmissiveColor;

		private void Awake()
		{
			_material = GetComponent<Renderer>().material;
			_originalEmissiveColor = _material.GetColor(EmissiveColorProperty);
		}

		public void Highlight()
		{
			if (!enabled)
				return;

			var routine = Routines.MaterialEmissiveColorLerp(
				_material,
				LevelMenuSettings.Instance.cubeHighlighter.emissiveColor,
				LevelMenuSettings.Instance.cubeHighlighter.duration,
				Math.EaseOutCubic);

			StopAllCoroutines();
			StartCoroutine(routine);
		}

		public void Unhighlight()
		{
			if (!enabled)
				return;

			var routine = Routines.MaterialEmissiveColorLerp(
				_material,
				_originalEmissiveColor,
				LevelMenuSettings.Instance.cubeHighlighter.duration,
				Math.EaseInCubic);

			StopAllCoroutines();
			StartCoroutine(routine);
			
			StopAllCoroutines();
			StartCoroutine(routine);
		}
	}
}