using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(Image))]
	public class ButtonLockableFeature : MonoBehaviour
	{
		[SerializeField] private bool isLocked;

		private Button _button;
		private Image _image;

		public bool IsLocked
		{
			get => isLocked;

			set
			{
				isLocked = value;
				UpdateState();
			}
		}

		private void Awake()
		{
			_button = GetComponent<Button>();
			_image = GetComponent<Image>();
		}

		private void Start()
		{
			UpdateState();
		}

		private void UpdateState()
		{
			if (IsLocked)
			{
				_button.interactable = false;
				_image.color = ButtonLockableFeatureSettings.Find().lockedColor;
			}
			else
			{
				_button.interactable = true;
				_image.color = Color.white;
			}
		}
	}
}