using Common;
using Game.Common;
using UnityEngine;

namespace Level
{
	public class MusicRestarter : MonoBehaviour
	{
		private void Start()
		{
			try
			{
				Finder.FindMandatory<MusicPlayer>().Play();
			}
			catch (Finder.MandatoryObjectNotFound)
			{
				Debug.LogError("Can't find music player");
			}
		}
	}
}