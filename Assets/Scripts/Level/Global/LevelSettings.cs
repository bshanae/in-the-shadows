using System;
using UnityEngine;

namespace Level
{
	public class LevelSettings : MonoBehaviour
	{
		public static LevelSettings Instance { get; private set; }

		[Serializable]
		public struct FigureRotator
		{
			public float sensitivity;
		}

		[Serializable]
		public struct FigureSetRotator
		{
			public float sensitivity;
		}
	
		[Serializable]
		public struct FigureRotationSupervisor
		{
			public Vector3 threshold;
		}

		[Serializable]
		public struct FigureSetRotationSupervisor
		{
			public float threshold;
		}

		public FigureRotator figureRotator; 
		public FigureSetRotator figureSetRotator;
		public FigureRotationSupervisor figureRotationSupervisor;
		public FigureSetRotationSupervisor figureSetRotationSupervisor;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}