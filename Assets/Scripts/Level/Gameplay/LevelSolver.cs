using System;
using System.Collections;
using System.Linq;
using Common;
using Common.Input;
using Common.UI;
using UnityEngine;

namespace Level
{
	public class LevelSolver : MonoBehaviour
	{
		[SerializeField] private ButtonLockableFeature nextLevelButton;

		private FigureSetSolver _figureSet;
		private FigureSolver[] _figures;

		private bool _areFiguresLoaded;
		private bool _isWaitingForSolution;

		private bool IsSolved
		{
			get
			{
				if (_figureSet != null && !_figureSet.IsSolved)
					return false;

				return _figures.All(figure => figure.IsSolved);
			}
		}

		private bool IsBusy
		{
			get
			{
				if (_figureSet != null && _figureSet.IsBusy)
					return true;

				return _figures.Any(figure => figure.IsBusy);
			}
		}

		private bool ShouldTryToSolve => _areFiguresLoaded && _isWaitingForSolution; 

		private void Awake()
		{
			_isWaitingForSolution = true;

			var figureLoader = Finder.Find<FigureLoader>();

			if (figureLoader != null)
				figureLoader.FigureLoaded += OnFigureLoaded;
		}

		private void OnDestroy()
		{
			var figureLoader = Finder.Find<FigureLoader>();

			if (figureLoader != null)
				figureLoader.FigureLoaded -= OnFigureLoaded;
		}

		private void Update()
		{
			if (ShouldTryToSolve && IsSolved)
			{
				_isWaitingForSolution = false;
				ShowExactSolution(() => nextLevelButton.IsLocked = false);
			}
		}

		private void OnFigureLoaded()
		{
			_figureSet = Finder.Find<FigureSetSolver>();
			_figures = Finder.FindAll<FigureSolver>();

			_areFiguresLoaded = true;
		}

		public void SolveAutomatically()
		{
			_isWaitingForSolution = false;
			ShowExactSolution(() => nextLevelButton.IsLocked = false);
		}

		private void ShowExactSolution(Action onFinish = null)
		{
			StartCoroutine(Routine());

			IEnumerator Routine()
			{
				InputTools.DisableAllInput();

				if (_figureSet != null)
					_figureSet.ShowExactSolution();

				foreach (var figure in _figures)
					figure.ShowExactSolution();

				while (IsBusy)
					yield return null;
				
				InputTools.EnableAllInput();
				onFinish?.Invoke();
			}
		}
	}
}