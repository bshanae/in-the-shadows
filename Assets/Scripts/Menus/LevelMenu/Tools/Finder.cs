using UnityEngine;
using UnityEngine.Assertions;

namespace LevelMenu
{
	public static class Finder
	{
		public static Camera FindCamera()
		{
			var camera = Camera.main;

			Assert.IsNotNull(camera);
			return camera;
		}

		public static CameraMover FindCameraMover()
		{
			var camera = FindCamera();
			var cameraMover = camera.GetComponent<CameraMover>();

			Assert.IsNotNull(cameraMover);
			return cameraMover;
		}
	}
}