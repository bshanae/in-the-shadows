using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace Common
{
	public class SceneLightingFader : SceneFader
	{
		private interface Emitter
		{
			public void SetIntensity(float intensity);
		}
	
		private class Light : Emitter
		{
			private readonly UnityEngine.Light _light;
			private readonly float _originalIntensity;

			public Light(UnityEngine.Light light)
			{
				_light = light;
				_originalIntensity = light.intensity;
			}

			public void SetIntensity(float intensity)
			{
				_light.intensity = _originalIntensity * intensity;
			}
		}

		private class MaterialWithEmission : Emitter
		{
			private static readonly int EmissiveColor = Shader.PropertyToID("_EmissiveColor");

			private readonly Material _material;
			private readonly Color _emission;

			public MaterialWithEmission(Material material)
			{
				_material = material;
				_emission = _material.GetColor(EmissiveColor).gamma;
			}

			public void SetIntensity(float intensity)
			{
				var color = Color.Lerp(Color.black, _emission, intensity);
				_material.SetColor(EmissiveColor, color.linear);
			}
		}

		private List<Emitter> _emitters;
		
		private void Awake()
		{
			_emitters = new List<Emitter>();
			_emitters.AddRange(FindLights());
			_emitters.AddRange(FindEmissiveMaterials());

			static IEnumerable<Emitter> FindLights()
			{
				return FindObjectsOfType<UnityEngine.Light>().Select(light => new Light(light));
			}

			static IEnumerable<Emitter> FindEmissiveMaterials()
			{
				var materials = new HashSet<Material>();

				foreach (var renderer in FindObjectsOfType<Renderer>())
				foreach (var material in renderer.materials)
				{
					materials.Add(material);
				}

				return materials.Select(material => new MaterialWithEmission(material));
			}
		}

		protected override IEnumerator FadingInRoutine(float duration)
		{
			return FadingRoutine(0, 1, duration);
		}

		protected override IEnumerator FadingOutRoutine(float duration)
		{
			return FadingRoutine(1, 0, duration);
		}
		
		private IEnumerator FadingRoutine(float startIntensity, float finishIntensity, float duration)
		{
			var step = (finishIntensity - startIntensity) / duration;
			var intensity = startIntensity;
			
			ApplyIntensityToLights(intensity);
			yield return null;

			do
			{
				intensity += step * Time.deltaTime;
				ApplyIntensityToLights(intensity);

				yield return null;
			} while (!Math.HaveReachedValue(startIntensity, finishIntensity, intensity));
		}

		private void ApplyIntensityToLights(float intensity)
		{
			foreach (var emitter in _emitters)
				emitter.SetIntensity(intensity);
		}
	}
}