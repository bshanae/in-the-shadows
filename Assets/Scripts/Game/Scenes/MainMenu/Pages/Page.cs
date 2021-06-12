using UnityEngine;

namespace MainMenu
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(CanvasGroup))]
	public abstract class Page : MonoBehaviour
	{
		private CanvasGroup _canvasGroup;
		private bool _isEnabled;

		public bool IsEnabled
		{
			get => _isEnabled;
			set
			{
				_canvasGroup.interactable = value;
				_canvasGroup.blocksRaycasts = value;
				_isEnabled = value;
			}
		}

		public float Alpha
		{
			get => _canvasGroup.alpha;
			set => _canvasGroup.alpha = value;
		}

		protected virtual void Awake()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
		}
	}
}