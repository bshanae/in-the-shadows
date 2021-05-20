using System;
using UnityEngine;

namespace Menus.LevelMenu
{
	public class CubeRotationRestorerSettings : MonoBehaviour
	{
		public static CubeRotationRestorerSettings Instance { get; private set; }

		public float speed;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}