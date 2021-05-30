using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
			[ColorUsage(false, true)] public Color startEmission;
			[ColorUsage(false, true)] public Color finishEmission;

			public float duration;
		}

		[Serializable]
		public struct LevelNameSetter
		{
			public TextMeshProUGUI levelName;
		}

		public CameraMover cameraMover;
		public CubeRotator cubeRotator;
		public CubeRestorer cubeRestorer;
		public CubeHighlighter cubeHighlighter;
		public LevelNameSetter levelNameSetter;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}