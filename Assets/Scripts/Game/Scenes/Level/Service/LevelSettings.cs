using System;
using Common;
using UnityEngine;

namespace Level
{
	public class LevelSettings : MonoBehaviour
	{
		public static LevelSettings Instance { get; private set; }

		[Serializable]
		public struct FigureRotator
		{
			public FigureRotationMode rotationMode;
			public float sensitivity;
		}

		[Serializable]
		public struct FigureSetRotator
		{
			public FigureSetRotationMode rotationMode;
			public float sensitivity;
		}
	
		[Serializable]
		public struct FigureSolver
		{
			public float threshold;
			public float exactSolutionAnimationDuration;
		}

		[Serializable]
		public struct FigureSetSolver
		{
			public float threshold;
			public float exactSolutionAnimationDuration;
		}

		public FigureRotator figureRotator; 
		public FigureSetRotator figureSetRotator;
		public FigureSolver figureSolver;
		public FigureSetSolver figureSetSolver;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}