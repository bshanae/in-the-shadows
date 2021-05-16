using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Game
{
	[RequireComponent(typeof(Volume))]
	public class VignetteFader : MonoBehaviour
	{
		[SerializeField] private float fadingDuration;

		private Volume _volume;

		private void Awake()
		{
			_volume = GetComponent<Volume>();
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
			var step = (finishWeight - startWeight) / fadingDuration;

			_volume.weight = startWeight;

			while (Mathf.Abs(_volume.weight - finishWeight) > float.Epsilon)
			{
				_volume.weight += step * Time.deltaTime;
				yield return null;
			}

			_volume.weight = finishWeight;
		}
	}
}