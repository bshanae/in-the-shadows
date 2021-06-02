using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace Common
{
	public static class Finder
	{
		public class MandatoryObjectNotFound : Exception {}

		public static Camera FindCamera()
		{
			var camera = Camera.main;

			Assert.IsNotNull(camera);
			return camera;
		}

		public static T Find<T>() where T : MonoBehaviour
		{
			return Object.FindObjectsOfType<T>().FirstOrDefault();
		}

		public static T FindMandatory<T>() where T : MonoBehaviour
		{
			var @object = Object.FindObjectsOfType<T>().FirstOrDefault();

			if (@object == null)
				throw new MandatoryObjectNotFound();

			return @object;
		}

		public static T[] FindAll<T>() where T : MonoBehaviour
		{
			return Object.FindObjectsOfType<T>();
		}
	}
}