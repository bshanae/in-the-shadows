using Common.Debugging;
using UnityEditor;
using UnityEngine;

namespace Editor
{
	[CustomEditor(typeof(FigureHelper))]
	public class FigureHelperInspector : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (GUILayout.Button("Solve"))
			{
				var helper = (FigureHelper)target;
				helper.Solve();
			}
		}
	}
}