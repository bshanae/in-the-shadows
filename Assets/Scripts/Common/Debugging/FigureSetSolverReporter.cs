using Level;
using UnityEngine;

namespace Common.Debugging
{
	[RequireComponent(typeof(FigureSetSolver))]
	public class FigureSetSolverReporter : MonoBehaviour
	{
		[SerializeField] private bool isSolved;

		private FigureSetSolver _figureSetSolver;

		private void Awake()
		{
			_figureSetSolver = GetComponent<FigureSetSolver>();
		}

		private void Update()
		{
			isSolved = _figureSetSolver.IsSolved;
		}
	}
}