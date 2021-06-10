using System;
using UnityEngine;

namespace Common
{
	public abstract class SceneMetaLoader : MonoBehaviour
	{
		private bool _isMetaLoaded;

		protected void VerifyThatLoaded()
		{
			if (!_isMetaLoaded)
				throw new Exception("Meta is not loaded");
		}

		protected abstract void LoadMeta(SceneMeta meta);

		private void Awake()
		{
			try
			{
				LoadMeta(SceneMetaCourier.Instance.SceneMeta);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("Parsing error");
			}
			finally
			{
				_isMetaLoaded = true;
			}
		}
	}
}