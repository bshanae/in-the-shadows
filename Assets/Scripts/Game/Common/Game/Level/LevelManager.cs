using System.Linq;
using UnityEngine;

namespace Common
{
	public class LevelManager
	{
		private static LevelManager _instance;

		public static LevelManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new LevelManager();

				return _instance;
			}
		}

		public LevelConfiguration[] Configurations { get; }

		private LevelManager()
		{
			var unsorted = Resources.FindObjectsOfTypeAll<LevelConfiguration>();
			var sorted = unsorted.OrderBy(configuration => configuration.LevelIndex).ToArray();

			Configurations = sorted;
		}
	}
}