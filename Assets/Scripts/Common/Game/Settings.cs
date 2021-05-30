using UnityEngine;

namespace Common
{
	public class Settings<T> : MonoBehaviour where T : Settings<T>
	{
		public static T Find()
		{
			return Finder.FindSettings<T>();
		}
	}
}