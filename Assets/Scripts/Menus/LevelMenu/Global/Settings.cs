using System;
using UnityEngine;

namespace LevelMenu
{
	public class Settings : MonoBehaviour
	{
		public static Settings Instance { get; private set; }

		[Serializable]
		public struct CameraMover
		{
			public float threshold;
		}

		[Serializable]
		public struct CubeRotator
		{
			public float sensitivity;
			public float importanceThreshold;
		}

		[Serializable]
		public struct CubeRestorer
		{
			public float speed;
		}

		[Serializable]
		public struct CubeHighlighter
		{
			[ColorUsage(false, true)] public Color startGlow;
			[ColorUsage(false, true)] public Color finishGlow;
			public float duration;
		}

		public CameraMover cameraMover;
		public CubeRotator cubeRotator;
		public CubeRestorer cubeRestorer;
		public CubeHighlighter cubeHighlighter;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}