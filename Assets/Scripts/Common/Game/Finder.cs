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

		public static T FindSettings<T>() where T : MonoBehaviour
		{
			var @object = GameObject.FindGameObjectWithTag("Settings");
			var settings = @object.GetComponent<T>();

			return settings;
		}

		public static InputDelegate[] FindInputDelegates()
		{
			return Object.FindObjectsOfType<InputDelegate>();
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