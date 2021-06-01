using System;
using System.Collections;
using System.Linq;
using Common.Input;
using Common.UI;
using UnityEngine;

namespace Level
{
	public class LevelSolver : MonoBehaviour
	{
		[SerializeField] private FigureSetSolver figureSet;
		[SerializeField] private FigureSolver[] figures;
		[SerializeField] private ButtonLockableFeature nextLevelButton;

		private bool _waitingForSolution;

		private bool IsSolved
		{
			get
			{
				if (figureSet != null && !figureSet.IsSolved)
					return false;

				return figures.All(figure => figure.IsSolved);
			}
		}

		private bool IsBusy
		{
			get
			{
				if (figureSet != null && figureSet.IsBusy)
					return true;

				return figures.Any(figure => figure.IsBusy);
			}
		}

		private void Awake()
		{
			_waitingForSolution = true;
		}

		private void Update()
		{
			if (_waitingForSolution && IsSolved)
			{
				_waitingForSolution = false;
				ShowExactSolution(() => nextLevelButton.IsLocked = false);
			}
		}

		public void SolveAutomatically()
		{
			_waitingForSolution = false;
			ShowExactSolution(() => nextLevelButton.IsLocked = false);
		}

		private void ShowExactSolution(Action onFinish = null)
		{
			StartCoroutine(Routine());

			IEnumerator Routine()
			{
				InputTools.DisableAllInput();

				if (figureSet != null)
					figureSet.ShowExactSolution();

				foreach (var figure in figures)
					figure.ShowExactSolution();

				while (IsBusy)
					yield return null;
				
				InputTools.EnableAllInput();
				onFinish?.Invoke();
			}
		}
	}
}