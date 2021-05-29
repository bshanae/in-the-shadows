using System.Collections;
using UnityEngine;

namespace LevelMenu
{
	public class CubeHighlighter : MonoBehaviour
	{
		private static readonly int EmissiveColor = Shader.PropertyToID("_EmissiveColor");

		private Material _material;

		private void Awake()
		{
			_material = GetComponent<Renderer>().material;
		}

		public void Highlight()
		{
			StopAllCoroutines();
			StartCoroutine(HighlightingRoutine(Settings.Instance.cubeHighlighter.finishEmission));
		}

		public void Unhighlight()
		{
			StopAllCoroutines();
			StartCoroutine(HighlightingRoutine(Settings.Instance.cubeHighlighter.startEmission));
		}

		private IEnumerator HighlightingRoutine(Color targetColor)
		{
			var startColor = _material.GetColor(EmissiveColor).gamma;
			var finishColor = targetColor;

			var progress = 0f;

			do
			{
				progress += Time.deltaTime / Settings.Instance.cubeHighlighter.duration;

				var color = Color.Lerp(startColor, finishColor, progress);
				_material.SetColor(EmissiveColor, color.linear);

				yield return null;
			} while (progress < 1f);
		}
	}
}