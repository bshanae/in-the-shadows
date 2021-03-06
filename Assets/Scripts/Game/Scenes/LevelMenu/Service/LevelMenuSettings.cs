using System;
using UnityEngine;

namespace LevelMenu
{
	public class LevelMenuSettings : MonoBehaviour
	{
		public static LevelMenuSettings Instance { get; private set; }

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
			[ColorUsage(false, true)] public Color emissiveColor;
			public float duration;
		}

		[Serializable]
		public struct CubeSoundPlayer
		{
			public AudioClip clickSound;
		}

		[Serializable]
		public struct LevelLocker
		{
			public Color lockedBaseColor;

			[ColorUsage(false, true)] public Color unlockEmissiveColor;
			public float unlockDuration;
		}

		public CameraMover cameraMover;
		public CubeRotator cubeRotator;
		public CubeRestorer cubeRestorer;
		public CubeHighlighter cubeHighlighter;
		public CubeSoundPlayer cubeSoundPlayer;
		public LevelLocker levelLocker;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}