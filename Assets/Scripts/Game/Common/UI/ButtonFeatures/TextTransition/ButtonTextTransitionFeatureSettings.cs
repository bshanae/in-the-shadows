using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Common.UI
{
	public class ButtonTextTransitionFeatureSettings : Settings<ButtonTextTransitionFeatureSettings>
	{
		public TMP_FontAsset defaultFont;
		public TMP_FontAsset pressedFont;
	}
}