using System;
using UnityEngine;

namespace Game
{
	public class Settings : MonoBehaviour
	{
		public static Settings Instance { get; private set; }

		[Serializable]
		public struct FigureRotator
		{
			public float sensitivity;
		}

		public FigureRotator figureRotator; 

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}