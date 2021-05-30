using System;
using UnityEngine;

namespace Game
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

		public FigureRotator figureRotator; 
		public FigureSetRotator figureSetRotator; 

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}