using Common.Debugging;
using UnityEditor;
using UnityEngine;

namespace Editor
{
	[CustomEditor(typeof(FigureSetHelper))]
	public class FigureSetHelperInspector : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (GUILayout.Button("Solve"))
			{
				var helper = (FigureSetHelper)target;
				helper.Solve();
			}
		}
	}
}