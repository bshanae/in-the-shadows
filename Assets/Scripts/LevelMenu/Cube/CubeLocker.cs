using System.Collections;
using UnityEngine;

namespace LevelMenu
{
	public class CubeLocker : MonoBehaviour
	{
		private static readonly int BaseColorProperty = Shader.PropertyToID("_BaseColor");
		private static readonly int EmissiveColorProperty = Shader.PropertyToID("_EmissiveColor");

		private Material _material;

		private Color _originalBaseColor;
		private Color _originalEmissiveColor;

		private void Awake()
		{
			_material = GetComponent<Renderer>().material;

			_originalBaseColor = _material.GetColor(BaseColorProperty);
			_originalEmissiveColor = _material.GetColor(EmissiveColorProperty);
		}

		public void Lock()
		{
			var targetBaseColor = LevelMenuSettings.Instance.levelLocker.baseColor;
			var targetEmissiveColor = LevelMenuSettings.Instance.levelLocker.emissiveColor;

			_material.SetColor(BaseColorProperty, targetBaseColor);
			_material.SetColor(EmissiveColorProperty, targetEmissiveColor);
		}

		public void ShowUnlockAnimation()
		{
			Lock();
			StopAllCoroutines();

			StartCoroutine(ColorChangeRoutine(BaseColorProperty, _originalBaseColor));
			StartCoroutine(ColorChangeRoutine(EmissiveColorProperty, _originalEmissiveColor));
		}

		private IEnumerator ColorChangeRoutine(int property, Color targetColor)
		{
			var startColor = _material.GetColor(property).gamma;
			var progress = 0f;

			do
			{
				progress += Time.deltaTime / LevelMenuSettings.Instance.levelLocker.duration;

				var color = Color.Lerp(startColor, targetColor, progress);
				_material.SetColor(property, color.linear);

				yield return null;
			} while (progress < 1f);
		}
	}
}