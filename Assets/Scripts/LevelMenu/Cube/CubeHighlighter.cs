using System.Collections;
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

			StopAllCoroutines();
			StartCoroutine(HighlightingRoutine(LevelMenuSettings.Instance.cubeHighlighter.emissiveColor));
		}

		public void Unhighlight()
		{
			if (!enabled)
				return;
			
			StopAllCoroutines();
			StartCoroutine(HighlightingRoutine(_originalEmissiveColor));
		}

		private IEnumerator HighlightingRoutine(Color targetColor)
		{
			var startColor = _material.GetColor(EmissiveColorProperty).gamma;
			var progress = 0f;

			do
			{
				progress += Time.deltaTime / LevelMenuSettings.Instance.cubeHighlighter.duration;

				var color = Color.Lerp(startColor, targetColor, progress);
				_material.SetColor(EmissiveColorProperty, color.linear);

				yield return null;
			} while (progress < 1f);
		}
	}
}