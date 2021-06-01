using System.Collections;
using UnityEngine;

namespace Level
{
	[RequireComponent(typeof(Renderer))]
	public class FigureSolver : MonoBehaviour
	{
		[SerializeField] private Vector3 targetGlobalRotation;
		[SerializeField] private Vector3 targetLocalRotation;

		public bool IsSolved { get; private set; }
		public bool IsBusy { get; private set; }

		private Quaternion CurrentRotationQuaternion => transform.rotation;
		private Quaternion TargetRotationQuaternion => Quaternion.Euler(targetGlobalRotation);
		private float Threshold => LevelSettings.Instance.figureSolver.threshold;

		private void Update()
		{
			IsSolved = Quaternion.Angle(CurrentRotationQuaternion, TargetRotationQuaternion) < Threshold;
		}

		public void ShowExactSolution()
		{
			StartCoroutine(Routine());
		
			IEnumerator Routine()
			{
				IsBusy = true;

				var speed = 1f / LevelSettings.Instance.figureSolver.exactSolutionAnimationDuration;
				var progress = 0f;

				var startRotation = transform.localRotation;
				var targetRotationAsQuaternion = Quaternion.Euler(targetLocalRotation);

				do
				{
					progress += speed * Time.deltaTime;
					transform.localRotation = Quaternion.Slerp(startRotation, targetRotationAsQuaternion, progress);

					yield return null;
				} while (progress <= 1f);

				IsBusy = false;
			}
		}
	}
}