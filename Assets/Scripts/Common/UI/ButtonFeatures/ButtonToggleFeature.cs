using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Common.UI
{
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(Image))]
	public class ButtonToggleFeature : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		[SerializeField] private Sprite defaultSprite;
		[SerializeField] private Sprite pressedSprite;

		private Image _image;
		private bool _state;

		public bool State => _state;

		private void Awake()
		{
			_image = GetComponent<Image>();
			_state = true;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_state = !_state;

			_image.sprite = pressedSprite;
			_image.color = Settings.Instance.buttonToggleFeature.onColor;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_image.sprite = defaultSprite;

			if (!_state)
				_image.color = Settings.Instance.buttonToggleFeature.offColor;
		}
	}
}