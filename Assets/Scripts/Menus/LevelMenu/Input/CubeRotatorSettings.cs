using System;
using UnityEngine;

namespace LevelMenu
{
	public class CubeRotatorSettings : MonoBehaviour
	{
		public static CubeRotatorSettings Instance { get; private set; }

		public float sensitivity;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}