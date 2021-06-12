using System;
using UnityEngine;

namespace Game.Common
{
	public class AudioSettings
	{
		public static AudioSettings Instance => _instance ??= new AudioSettings();

		private static AudioSettings _instance;

		private static class PreferencesKeys
		{
			public const string CanPlaySounds = "can_play_sounds"; 
			public const string CanPlayMusic = "can_play_music";  
		}

		public bool CanPlaySounds
		{
			get => _canPlaySounds;

			set
			{
				_canPlaySounds = value;
				Save();

				if (_canPlaySounds)
					SoundEnabled?.Invoke();
				else
					SoundDisabled?.Invoke();
			}
		}
		public bool CanPlayMusic
		{
			get => _canPlayMusic;

			set
			{
				_canPlayMusic = value;
				Save();
				
				if (_canPlayMusic)
					MusicEnabled?.Invoke();
				else
					MusicDisabled?.Invoke();
			}
		}

		public event Action SoundEnabled;
		public event Action SoundDisabled;
		public event Action MusicEnabled;
		public event Action MusicDisabled;

		private bool _canPlaySounds;
		private bool _canPlayMusic;

		private AudioSettings()
		{
			Load();
		}

		private void Load()
		{
			CanPlaySounds = GetBool(PreferencesKeys.CanPlaySounds) ?? false;
			CanPlayMusic = GetBool(PreferencesKeys.CanPlayMusic) ?? false;
		}

		private void Save()
		{
			SetBool(PreferencesKeys.CanPlaySounds, CanPlaySounds);
			SetBool(PreferencesKeys.CanPlayMusic, CanPlayMusic);	
		}

		private static bool? GetBool(string key)
		{
			return PlayerPrefs.GetInt(key, -1) switch
			{
				1 => true,
				0 => false,
				_ => null
			};
		}

		private static void SetBool(string key, bool value)
		{
			PlayerPrefs.SetInt(key, value ? 1 : 0);
		}

	}
}