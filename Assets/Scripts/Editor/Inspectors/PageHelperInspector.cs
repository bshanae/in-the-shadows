using MainMenu;
using UnityEditor;
using UnityEngine;

namespace Editor
{
	[CustomEditor(typeof(PageHelper))]
	public class PageHelperInspector : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			var helper = (PageHelper)target;

			if (GUILayout.Button("Enable and show"))
			{
				helper.IsEnabled = true;
				helper.IsVisible = true;
			}

			if (GUILayout.Button("Disable and hide"))
			{
				helper.IsEnabled = false;
				helper.IsVisible = false;
			}
		}
	}
}