using UnityEngine;

namespace Common
{
	public class Settings<T> : MonoBehaviour where T : Settings<T>
	{
		public static T Find()
		{
			try
			{
				return Finder.FindMandatory<T>();
			}
			catch (Finder.MandatoryObjectNotFound)
			{
				Debug.LogError("Settings instance is not found!");
				return null;
			}
		}
	}
}