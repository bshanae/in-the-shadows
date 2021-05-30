using Common;
using UnityEngine;

namespace Level
{
	public class FigureRotationSupervisor : MonoBehaviour
	{
		[SerializeField] private Vector3 targetRotation;

		public bool IsSolved { get; private set; }

		private Vector3 CurrentRotation => transform.localRotation.eulerAngles;
		private Vector3 Threshold => LevelSettings.Instance.figureRotationSupervisor.threshold;

		private void Update()
		{
			IsSolved = MathTools.IsApproximatelyEqual(CurrentRotation, targetRotation, Threshold);
		}
	}
}