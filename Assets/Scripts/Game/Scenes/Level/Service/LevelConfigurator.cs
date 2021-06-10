using System;
using Common;
using UnityEngine;

namespace Level
{
	public class LevelConfigurator : MonoBehaviour
	{
		public LevelConfiguration levelConfiguration;

		public event Action LevelConfigurationApplied;

		private void Start()
		{
			GetConfiguration();
			ApplySettings();
		}

		private void GetConfiguration()
		{
			var levelIndex = Finder.FindMandatory<LevelMetaLoader>().LevelIndex;
			levelConfiguration = LevelManager.Instance.FindLevelConfiguration(levelIndex);
		}

		private void ApplySettings()
		{
			var settings = Finder.FindMandatory<LevelSettings>();

			settings.figureRotator.rotationMode = levelConfiguration.FigureRotationMode;
			settings.figureSolver.threshold = levelConfiguration.FigureSolutionThreshold;

			settings.figureSetRotator.rotationMode = levelConfiguration.FigureSetRotationMode;
			settings.figureSetSolver.threshold = levelConfiguration.FigureSetSolutionThreshold;

			LevelConfigurationApplied?.Invoke();
		}
	}
}