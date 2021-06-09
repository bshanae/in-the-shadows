using System.Collections;
using Common;
using UnityEngine;

namespace Level
{
	public class FigureSetSolver : MonoBehaviour
	{
		[SerializeField] private Vector3 targetRotation;

		public bool IsSolved { get; private set; }
		public bool IsBusy { get; private set; }

		private Quaternion CurrentRotationQuaternion => Quaternion.Euler(transform.rotation.eulerAngles);
		private Quaternion TargetRotationQuaternion => Quaternion.Euler(targetRotation);
		private float Threshold => LevelSettings.Instance.figureSetSolver.threshold;

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

				var speed = 1f / LevelSettings.Instance.figureSetSolver.exactSolutionAnimationDuration;
				var progress = 0f;

				var startRotation = transform.rotation;
				var targetRotationAsQuaternion = Quaternion.Euler(targetRotation);

				yield return null;

				do
				{
					progress += speed * Time.deltaTime;
					transform.rotation = Quaternion.Slerp(startRotation, targetRotationAsQuaternion, progress);

					yield return null;
				} while (progress <= 1f);

				IsBusy = false;
			}
		}
	}
}