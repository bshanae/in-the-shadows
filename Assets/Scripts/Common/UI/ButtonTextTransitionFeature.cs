using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Common
{
	[RequireComponent(typeof(Button))]
	public class ButtonTextTransitionFeature : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		[SerializeField] private TextMeshProUGUI text;

		public void OnPointerDown(PointerEventData eventData)
		{
			text.font = ButtonTextTransitionFeatureSettings.Instance.pressedFont;
			text.UpdateFontAsset();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			text.font = ButtonTextTransitionFeatureSettings.Instance.defaultFont;
			text.UpdateFontAsset();
		}
	}
}