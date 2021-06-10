using System.Linq;
using UnityEngine;

namespace Common
{
	public class LevelManager
	{
		public static LevelManager Instance => _instance ??= new LevelManager();

		public LevelConfiguration[] Configurations { get; }

		public LevelConfiguration FindLevelConfiguration(int index)
		{
			return Configurations.FirstOrDefault(configuration => configuration.LevelIndex == index);
		}

		private static LevelManager _instance;

		private LevelManager()
		{
			var unsorted = Resources.LoadAll<LevelConfiguration>("Levels");
			var sorted = unsorted.OrderBy(configuration => configuration.LevelIndex).ToArray();

			Configurations = sorted;
		}
	}
}