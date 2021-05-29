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

		public bool State { get; private set; }

		private void Awake()
		{
			_image = GetComponent<Image>();
			State = true;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			State = !State;

			_image.sprite = pressedSprite;
			_image.color = Settings.Instance.buttonToggleFeature.onColor;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_image.sprite = defaultSprite;

			if (!State)
				_image.color = Settings.Instance.buttonToggleFeature.offColor;
		}
	}
}