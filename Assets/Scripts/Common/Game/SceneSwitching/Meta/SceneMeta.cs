using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
	public class SceneMeta
	{
		public class CantGetField : Exception {}

		private readonly Dictionary<string, object> _data;

		public SceneMeta()
		{
			_data = new Dictionary<string, object>();
		}

		public void PutField<T>(string key, T value)
		{
			_data[key] = value;
		}

		public T GetField<T>(string key)
		{
			try
			{
				var value = _data[key];
				return (T) value;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				throw new CantGetField();
			}
		}
	}
}