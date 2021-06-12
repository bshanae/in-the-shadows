using UnityEngine;

namespace MainMenu
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Page))]
	public class PageHelper : MonoBehaviour
	{
		private Page _page;

		public bool IsEnabled
		{
			set => _page.IsEnabled = value;
		}

		public bool IsVisible
		{
			set => _page.Alpha = value ? 1 : 0;
		}

		private void Awake()
		{
			_page = GetComponent<Page>();
		}
	}
}