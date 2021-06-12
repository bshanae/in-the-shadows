using Common;
using UnityEngine;

namespace Game.Common
{
	public class MusicPlayerCreator : MonoBehaviour
	{
		private void Awake()
		{
			if (Finder.Find<MusicPlayer>() == null)
			{
				var gameObject = new GameObject();
				gameObject.AddComponent<MusicPlayer>();
			}
		}
	}
}