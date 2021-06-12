using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Common
{
	public class MusicPlayer : MonoBehaviour
	{
		public enum ClipId
		{
			AnInnermostGlow
		}

		public void Play(ClipId id = DefaultClip)
		{
			var clip = _audioClips.Find(clip => clip.name == id.ToString());

			if (clip != null)
			{
				_audioSource.Stop();

				_audioSource.clip = clip;
				_audioSource.Play();
			}
			else
			{
				Debug.LogError($"Can't find clip with id {id}");
			}
		}

		private const ClipId DefaultClip = ClipId.AnInnermostGlow; 

		private AudioSource _audioSource;
		private List<AudioClip> _audioClips;

		private void Awake()
		{
			InitializeSelf();
			InitializeClips();

			Play();

			void InitializeSelf()
			{
				DontDestroyOnLoad(this);

				_audioSource = gameObject.AddComponent<AudioSource>();
				_audioSource.loop = true;
				_audioSource.volume = 0.5f;

				AudioSettings.Instance.MusicEnabled += OnMusicEnabled;
				AudioSettings.Instance.MusicDisabled += OnMusicDisabled;
			}

			void InitializeClips()
			{
				_audioClips = new List<AudioClip>();

				foreach (ClipId clip in Enum.GetValues(typeof(ClipId)))
					_audioClips.Add(Resources.Load<AudioClip>(GetPathToAudioClip(clip)));
			}
		}

		private void OnDestroy()
		{
			AudioSettings.Instance.MusicEnabled -= OnMusicEnabled;
			AudioSettings.Instance.MusicDisabled -= OnMusicDisabled;
		}

		private void OnMusicEnabled() => _audioSource.mute = true;
		private void OnMusicDisabled() => _audioSource.mute = false;

		private static string GetPathToAudioClip(ClipId id)
		{
			return $"Audio/{id}";
		}
	}
}