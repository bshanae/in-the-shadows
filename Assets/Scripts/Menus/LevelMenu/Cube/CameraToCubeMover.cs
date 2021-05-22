using Common;
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
			_cameraMover = Finder.FindCamera().GetComponent<CameraMover>();
			_collider = GetComponent<Collider>();
		}

		public bool TryMoveCameraToCube()
		{
			if (!_cameraMover.ShouldMoveTo(_collider.bounds.center.x))
				return false;

			return _cameraMover.MoveTo(_collider.bounds.center.x);
		}
	}
}