using Level;
using UnityEngine;

namespace Common.Debugging
{
	[RequireComponent(typeof(RotationHelper))]
	[RequireComponent(typeof(FigureSetSolver))]
	public class FigureSetHelper : MonoBehaviour
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

		public void Solve()
		{
			_figureSetSolver.ShowExactSolution();
		}
	}
}