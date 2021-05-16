using System;
using TMPro;
using UnityEngine;

namespace Common
{
	public class ButtonTextTransitionFeatureSettings : MonoBehaviour
	{
		public static ButtonTextTransitionFeatureSettings Instance { get; private set; }

		public TMP_FontAsset defaultFont;
		public TMP_FontAsset pressedFont;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("Instance is already set");

			Instance = this;
		}
	}
}