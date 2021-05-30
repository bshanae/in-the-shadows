using Common;
using UnityEngine;

namespace Level
{
	public class FigureSetRotationSupervisor : MonoBehaviour
	{
		[SerializeField] private float targetYRotation;

		public bool IsSolved { get; private set; }

		private float CurrentYRotation => transform.rotation.eulerAngles.y;
		private float Threshold => LevelSettings.Instance.figureSetRotationSupervisor.threshold; 

		private void Update()
		{
			IsSolved = MathTools.IsApproximatelyEqual(CurrentYRotation, targetYRotation, Threshold);
		}
	}
}