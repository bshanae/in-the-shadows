using System;
using UnityEngine;

namespace LevelMenu
{
	public class CubeInputSettings : MonoBehaviour
	{
		public static CubeInputSettings Instance { get; private set; }

		public float sensitivity;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}