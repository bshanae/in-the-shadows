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

		private Image _image;

		private void Awake()
		{
			_image = GetComponent<Image>();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_image.sprite = pressedSprite;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_image.sprite = defaultSprite;
		}
	}
}