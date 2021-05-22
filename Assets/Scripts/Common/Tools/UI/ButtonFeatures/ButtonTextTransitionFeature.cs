using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Common.UI
{
	[RequireComponent(typeof(Button))]
	public class ButtonTextTransitionFeature : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		[SerializeField] private TextMeshProUGUI text;

		public void OnPointerDown(PointerEventData eventData)
		{
			text.font = Settings.Instance.buttonTextTransitionFeature.pressedFont;
			text.UpdateFontAsset();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			text.font = Settings.Instance.buttonTextTransitionFeature.defaultFont;
			text.UpdateFontAsset();
		}
	}
}