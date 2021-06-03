using Level;
using UnityEngine;

namespace Common.Debugging
{
	[RequireComponent(typeof(RotationHelper))]
	[RequireComponent(typeof(FigureSolver))]
	public class FigureHelper : MonoBehaviour
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

		public void Solve()
		{
			_figureSolver.ShowExactSolution();
		}
	}
}