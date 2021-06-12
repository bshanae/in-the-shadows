using Common;
using UnityEngine;

using AudioSettings = Game.Common.AudioSettings; 

namespace LevelMenu
{
	[RequireComponent(typeof(AudioSource))]
	public class CubeSoundPlayer : MonoBehaviour
	{
		private AudioSource _audioSource;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
			_audioSource.clip = Finder.Find<LevelMenuSettings>().cubeSoundPlayer.clickSound;

			AudioSettings.Instance.SoundEnabled += OnSoundEnabled;
			AudioSettings.Instance.SoundDisabled += OnSoundDisabled;
		}

		private void OnDestroy()
		{
			AudioSettings.Instance.SoundEnabled -= OnSoundEnabled;
			AudioSettings.Instance.SoundDisabled -= OnSoundDisabled;
		}

		public void PlayClickSound()
		{
			_audioSource.Play();
		}

		private void OnSoundEnabled() => _audioSource.mute = true;
		private void OnSoundDisabled() => _audioSource.mute = false;
	}
}