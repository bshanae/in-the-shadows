using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
	[RequireComponent(typeof(Button))]
	public class ButtonWithTextFeatures : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		[SerializeField] private TextMeshProUGUI text;

		public void OnPointerDown(PointerEventData eventData)
		{
			text.font = ButtonSettings.Instance.pressedFont;
			text.UpdateFontAsset();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			text.font = ButtonSettings.Instance.defaultFont;
			text.UpdateFontAsset();
		}
	}
}