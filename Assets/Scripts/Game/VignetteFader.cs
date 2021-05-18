using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace Game
{
	[RequireComponent(typeof(PostProcessVolume))]
	public class VignetteFader : MonoBehaviour
	{
		[SerializeField] private float fadingDuration;

		private PostProcessVolume _volume;
		
		private void Awake()
		{
			_volume = GetComponent<PostProcessVolume>();
		}

		private void Start()
		{
			FadeIn();
		}

		public void FadeIn()
		{
			StartCoroutine(FadeCoroutine(1, 0));
		}

		private IEnumerator FadeCoroutine(float startWeight, float finishWeight)
		{
			var sign = Mathf.Sign(finishWeight - startWeight);
			var step = (finishWeight - startWeight) / fadingDuration;

			_volume.weight = startWeight;
			
			while (!DidFinish())
			{
				_volume.weight += step * Time.deltaTime;
				yield return null;
			}
			
			_volume.weight = finishWeight;

			bool DidFinish()
			{
				if (sign > 0f)
					return _volume.weight >= finishWeight;
				if (sign < 0f)
					return _volume.weight <= finishWeight;

				throw new Exception("Start and finish value are same");
			}
		}
	}
}