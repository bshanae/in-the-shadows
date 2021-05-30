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

		private Button _button;
		
		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (_button.interactable)
			{
				text.font = ButtonTextTransitionFeatureSettings.Find().pressedFont;
				text.UpdateFontAsset();
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			text.font = ButtonTextTransitionFeatureSettings.Find().defaultFont;
			text.UpdateFontAsset();
		}
	}
}