using UnityEngine;

namespace MainMenu
{
	[RequireComponent(typeof(CanvasGroup))]
	public abstract class Page : MonoBehaviour
	{
		public CanvasGroup canvasGroup;

		protected virtual void Awake()
		{
			canvasGroup = GetComponent<CanvasGroup>();
		}
	}
}