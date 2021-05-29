using System;
using TMPro;
using UnityEngine;

namespace Common.UI
{
	public class Settings : MonoBehaviour
	{
		[Serializable]
		public struct ButtonTextTransitionFeature
		{
			public TMP_FontAsset defaultFont;
			public TMP_FontAsset pressedFont;
		}

		[Serializable]
		public struct ButtonToggleFeature
		{
			public Color onColor;
			public Color offColor;
		}

		public static Settings Instance { get; private set; }

		public ButtonToggleFeature buttonToggleFeature;
		public ButtonTextTransitionFeature buttonTextTransitionFeature;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}