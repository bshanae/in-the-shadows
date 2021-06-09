using Common;
using UnityEngine;

namespace LevelMenu
{
	public class CubeLevelConfigurationHolder : MonoBehaviour
	{
		[SerializeField] private LevelConfiguration levelConfiguration;

		public LevelConfiguration LevelConfiguration => levelConfiguration;
		public Vector3 Position => transform.position;
	}
}