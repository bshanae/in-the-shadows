using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(Collider))]
	public class CameraToCubeMover : MonoBehaviour
	{
		[SerializeField] private CameraMover cameraMover;

		private Collider _collider;

		private void Awake()
		{
			_collider = GetComponent<Collider>();
		}

		public void TryMoveCameraToCube()
		{
			cameraMover.MoveTo(_collider.bounds.center.x);
		}
	}
}