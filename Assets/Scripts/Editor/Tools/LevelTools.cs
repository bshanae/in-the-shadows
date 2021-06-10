using UnityEditor;
using UnityEngine;

namespace Editor
{
	public static class LevelTools
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