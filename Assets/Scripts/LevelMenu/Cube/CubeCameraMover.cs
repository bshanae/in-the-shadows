using Common;
using UnityEngine;

namespace LevelMenu
{
	[RequireComponent(typeof(Collider))]
	public class CubeCameraMover : MonoBehaviour
	{
		private CameraMover _cameraMover;
		private Collider _collider;

		private void Awake()
		{
			_cameraMover = Finder.FindCamera().GetComponent<CameraMover>();
			_collider = GetComponent<Collider>();
		}

		public bool ShouldMoveCamera()
		{
			var center = _collider.bounds.center.z;
			return _cameraMover.ShouldMoveTo(center);
		}

		public bool TryMoveCamera()
		{
			var center = _collider.bounds.center.z;

			if (!_cameraMover.ShouldMoveTo(center))
				return false;

			return _cameraMover.MoveTo(center);
		}
	}
}