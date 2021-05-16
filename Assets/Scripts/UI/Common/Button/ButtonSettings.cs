using System;
using TMPro;
using UnityEngine;

namespace UI
{
	public class ButtonSettings : MonoBehaviour
	{
		public static ButtonSettings Instance { get; private set; }

		public TMP_FontAsset defaultFont;
		public TMP_FontAsset pressedFont;

		private void Awake()
		{
			if (Instance != null)
				throw new Exception("[ButtonSettings] Instance is already set");

			Instance = this;
		}
	}
}