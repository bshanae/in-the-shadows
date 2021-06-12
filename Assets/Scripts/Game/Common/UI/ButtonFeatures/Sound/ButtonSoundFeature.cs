using System;
using Common.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Common.UI
{
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(AudioSource))]
	public class ButtonSoundFeature : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		private AudioSource _audioSource;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
			_audioSource.clip = ButtonSoundFeatureSettings.Find().buttonClickSound;

			AudioSettings.Instance.SoundEnabled += OnSoundEnabled;
			AudioSettings.Instance.SoundDisabled += OnSoundDisabled;
		}

		private void OnDestroy()
		{
			AudioSettings.Instance.SoundEnabled -= OnSoundEnabled;
			AudioSettings.Instance.SoundDisabled -= OnSoundDisabled;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_audioSource.Play();
		}

		public void OnPointerUp(PointerEventData eventData)
		{}

		private void OnSoundEnabled() => _audioSource.mute = true;
		private void OnSoundDisabled() => _audioSource.mute = false;
	}
}