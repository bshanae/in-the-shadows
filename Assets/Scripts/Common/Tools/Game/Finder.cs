using Common.Input;
using UnityEngine;
using UnityEngine.Assertions;

namespace Common
{
	public static class Finder
	{
		public static Camera FindCamera()
		{
			var camera = Camera.main;

			Assert.IsNotNull(camera);
			return camera;
		}

		public static InputManager FindInputManager()
		{
			var @object = GameObject.FindGameObjectWithTag("InputManager");
			var inputManager = @object.GetComponent<InputManager>();

			Assert.IsNotNull(inputManager);
			return inputManager;
		}

		public static SceneSwitcher FindSceneSwitcher()
		{
			var @object = GameObject.FindGameObjectWithTag("SceneSwitcher");
			var sceneSwitcher = @object.GetComponent<SceneSwitcher>();

			Assert.IsNotNull(sceneSwitcher);
			return sceneSwitcher;
		}
	}
}