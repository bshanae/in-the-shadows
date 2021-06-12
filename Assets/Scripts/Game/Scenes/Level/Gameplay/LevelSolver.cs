using System;
using System.Collections;
using System.Linq;
using Common;
using Common.Input;
using UnityEngine;

namespace Level
{
	public class LevelSolver : MonoBehaviour
	{
		private const string SolvedClipPath = "Audio/Gong";

		private AudioSource _audioSource;

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

		private bool ShouldIncrementProgress
		{
			get
			{
				var thisLevel = Finder.Find<LevelMetaLoader>().LevelIndex;
				var currentPlayerLevel = PlayerProgress.Instance.CurrentLevelIndex;

				return thisLevel == currentPlayerLevel;
			}
		}

		private bool ShouldTryToSolve
		{
			get { return _areFiguresLoaded && _isWaitingForSolution; }
		}

		public event Action LevelSolved;

		private void Awake()
		{
			_audioSource = gameObject.AddComponent<AudioSource>();
			_audioSource.clip = Resources.Load<AudioClip>(SolvedClipPath);

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
				SolvePrecisely();
		}

		private void OnFigureLoaded()
		{
			_figureSet = Finder.Find<FigureSetSolver>();
			_figures = Finder.FindAll<FigureSolver>();

			_areFiguresLoaded = true;
		}

		public void SolvePrecisely()
		{
			_audioSource.Play();

			_isWaitingForSolution = false;
			StartCoroutine(Routine(OnRoutineFinished));

			IEnumerator Routine(Action onFinish = null)
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

			void OnRoutineFinished()
			{
				if (ShouldIncrementProgress)
				{
					PlayerProgress.Instance.IncrementLevel();
					PlayerProgress.Instance.SetNewLevelAsCurrent();
				}
				
				LevelSolved?.Invoke();
			}
		}
	}
}