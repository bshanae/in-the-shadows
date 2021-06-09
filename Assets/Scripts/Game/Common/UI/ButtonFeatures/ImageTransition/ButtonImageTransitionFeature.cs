using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Common.UI
{
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(Image))]
	public class ButtonImageTransitionFeature : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		[SerializeField] private Sprite defaultSprite;
		[SerializeField] private Sprite pressedSprite;

		private Button _button;
		private Image _image;

		private void Awake()
		{
			_button = GetComponent<Button>();
			_image = GetComponent<Image>();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (_button.interactable)
				_image.sprite = pressedSprite;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_image.sprite = defaultSprite;
		}
	}
}