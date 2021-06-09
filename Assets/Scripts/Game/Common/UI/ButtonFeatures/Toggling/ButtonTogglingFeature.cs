using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Common.UI
{
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(Image))]
	public class ButtonTogglingFeature : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		private Image _image;

		public bool State { get; private set; }

		private void Awake()
		{
			_image = GetComponent<Image>();
			State = true;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			State = !State;
			_image.color = ButtonTogglingFeatureSettings.Find().onColor;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (!State)
				_image.color = ButtonTogglingFeatureSettings.Find().offColor;
		}
	}
}