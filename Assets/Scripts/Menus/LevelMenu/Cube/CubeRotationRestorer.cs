using System.Collections;
using Common.Math;
using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CubeInput))]
	public class CubeRotationRestorer : MonoBehaviour
	{
		private CubeInput _cubeInput;
		private Coroutine _coroutine;

		private void Awake()
		{
			_cubeInput = GetComponent<CubeInput>();
		}

		private void Update()
		{
			if (!_cubeInput.HaveFocus && !transform.rotation.IsZero() && _coroutine == null)
				StartCoroutine(RestorationRoutine());
		}

		private IEnumerator RestorationRoutine()
		{
			var targetRotation = Quaternion.Euler(0, 0, 0);
			var progress = 0f;

			do
			{
				if (_cubeInput.HaveFocus)
				{
					_coroutine = null;
					yield break;
				}

				progress += Settings.Instance.cubeRestorer.speed * Time.time;
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, progress);

				yield return null;
			} while (progress <= 1f);

			_coroutine = null;
		}
	}
}