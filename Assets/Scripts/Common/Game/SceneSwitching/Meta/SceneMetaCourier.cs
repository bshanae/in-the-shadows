using UnityEngine;

namespace Common
{
	public class SceneMetaCourier : MonoBehaviour
	{
		private static SceneMetaCourier _instance;

		public static SceneMetaCourier Instance
		{
			get
			{
				if (_instance == null)
				{
					var gameObject = new GameObject {hideFlags = HideFlags.DontSave};
					_instance = gameObject.AddComponent<SceneMetaCourier>();
				}

				return _instance;
			}
		}

		public SceneMeta SceneMeta { get; set; }
	}
}