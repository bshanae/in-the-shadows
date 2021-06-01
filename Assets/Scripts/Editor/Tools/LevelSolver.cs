using UnityEditor;
using UnityEngine;

namespace Editor.Tools
{
	public static class LevelSolver
	{
		[MenuItem("Tools/Solve level")]
		public static void Solve()
		{
			var solver = Object.FindObjectOfType<Level.LevelSolver>();

			if (solver != null)
				solver.SolveAutomatically();
			else
				Debug.LogError("Level solver not found");
		}
	}
}