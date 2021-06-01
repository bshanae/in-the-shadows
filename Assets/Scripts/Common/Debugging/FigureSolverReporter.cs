using Level;
using UnityEngine;

namespace Common.Debugging
{
	[RequireComponent(typeof(FigureSolver))]
	public class FigureSolverReporter : MonoBehaviour
	{
		[SerializeField] private bool isSolved;

		private FigureSolver _figureSolver;

		private void Awake()
		{
			_figureSolver = GetComponent<FigureSolver>();
		}

		private void Update()
		{
			isSolved = _figureSolver.IsSolved;
		}
	}
}