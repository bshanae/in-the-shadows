using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(Collider))]
	public class CameraToCubeMover : MonoBehaviour
	{
		private CameraMover _cameraMover;
		private Collider _collider;

		private void Awake()
		{
			_cameraMover = Finder.FindCameraMover();
			_collider = GetComponent<Collider>();
		}

		public void TryMoveCameraToCube()
		{
			_cameraMover.MoveTo(_collider.bounds.center.x);
		}
	}
}