using System;
using UnityEngine;

namespace LevelMenu
{
	public class Settings : MonoBehaviour
	{
		public static Settings Instance { get; private set; }

		[Serializable]
		public struct CubeInput
		{
			public float sensitivity;
		}

		[Serializable]
		public struct CubeRestorer
		{
			public float speed;
		}

		[Serializable]
		public struct CameraToCubeMover
		{
			public float speed;
		}

		public CubeInput cubeInput;
		public CubeRestorer cubeRestorer;
		public CameraToCubeMover cameraToCubeMover;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}