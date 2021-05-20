using System.Collections;
using Common.Math;
using LevelMenu;
using UnityEngine;

namespace Menus.LevelMenu
{
	[RequireComponent(typeof(CubeRotator))]
	public class CubeRotationRestorer : MonoBehaviour
	{
		private CubeRotator _cubeRotator;
		private Coroutine _coroutine;

		private void Awake()
		{
			_cubeRotator = GetComponent<CubeRotator>();
		}

		private void Update()
		{
			if (!_cubeRotator.IsEnabled && !transform.rotation.IsZero() && _coroutine == null)
				StartCoroutine(RestorationRoutine());
		}

		private IEnumerator RestorationRoutine()
		{
			var targetRotation = Quaternion.Euler(0, 0, 0);
			var progress = 0f;

			do
			{
				if (_cubeRotator.IsEnabled)
				{
					_coroutine = null;
					yield break;
				}

				progress += CubeRotationRestorerSettings.Instance.speed * Time.time;
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, progress);

				yield return null;
			} while (progress <= 1f);

			_coroutine = null;
		}
	}
}