using System;
using UnityEngine;

namespace Common
{
	public class ButtonToggleFeatureSettings : MonoBehaviour
	{
		public static ButtonToggleFeatureSettings Instance { get; private set; }

		public Color onColor;
		public Color offColor;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}