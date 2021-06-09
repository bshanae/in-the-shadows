using System.Collections;
using Common;
using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(CubeInput))]
	public class CubeRotationRestorer : MonoBehaviour
	{
		private CubeInput _cubeInput;
		private bool _isBusy;

		private void Awake()
		{
			_cubeInput = GetComponent<CubeInput>();
		}

		private void Update()
		{
			if (!_cubeInput.HaveFocus && !transform.rotation.IsZero() && !_isBusy)
				StartCoroutine(RestorationRoutine());
		}

		private IEnumerator RestorationRoutine()
		{
			var startRotation = transform.rotation;
			var targetRotation = Quaternion.Euler(0, 0, 0);
			var progress = 0f;

			_isBusy = true;

			do
			{
				if (_cubeInput.HaveFocus)
				{
					_isBusy = false;
					yield break;
				}

				progress += LevelMenuSettings.Instance.cubeRestorer.speed * Time.time;
				transform.rotation = Quaternion.Slerp(startRotation, targetRotation, progress);

				yield return null;
			} while (progress <= 1f);

			_isBusy = false;
		}
	}
}