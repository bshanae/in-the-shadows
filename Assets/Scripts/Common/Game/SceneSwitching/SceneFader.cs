using System.Collections;
using UnityEngine;

namespace Common
{
	public abstract class SceneFader : MonoBehaviour
	{
		public float fadingDurationOverride;

		public bool IsRunning { get; private set; }

		public void FadeIn(float duration)
		{
			StopAllCoroutines();
			StartCoroutine(RoutineWrapper(FadingInRoutine(duration)));
		}

		public void FadeOut(float duration)
		{
			StopAllCoroutines();
			StartCoroutine(RoutineWrapper(FadingOutRoutine(duration)));
		}

		protected abstract IEnumerator FadingInRoutine(float duration);
		protected abstract IEnumerator FadingOutRoutine(float duration);

		private IEnumerator RoutineWrapper(IEnumerator baseRoutine)
		{
			IsRunning = true;
			yield return baseRoutine;
			IsRunning = false;
		}
	}
}