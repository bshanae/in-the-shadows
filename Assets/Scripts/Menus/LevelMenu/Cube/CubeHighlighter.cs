using System.Collections;
using UnityEngine;

namespace LevelMenu
{
	public class CubeHighlighter : MonoBehaviour
	{
		private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

		private Material _material;

		private void Awake()
		{
			_material = GetComponent<Renderer>().material;
			_material.EnableKeyword("_EMISSION");
		}

		public void Highlight()
		{
			StopAllCoroutines();
			StartCoroutine(HighlightingRoutine(Settings.Instance.cubeHighlighter.finishGlow));
		}

		public void Unhighlight()
		{
			StopAllCoroutines();
			StartCoroutine(HighlightingRoutine(Settings.Instance.cubeHighlighter.startGlow));
		}

		private IEnumerator HighlightingRoutine(Color targetColor)
		{
			var startColor = _material.GetColor(EmissionColor);
			var finishColor = targetColor;

			var progress = 0f;

			do
			{
				progress += Time.deltaTime / Settings.Instance.cubeHighlighter.duration;

				var color = Color.Lerp(startColor, finishColor, progress);
				_material.SetColor(EmissionColor, color);

				yield return null;
			} while (progress < 1f);
		}
	}
}