using JetBrains.Annotations;
using UnityEngine;
using AudioSettings = Game.Common.AudioSettings;

namespace MainMenu
{
    public class SettingsPage : Page
    {
        [SerializeReference] private Page mainPage;

        [UsedImplicitly]
        public void SoundButtonPressed()
        {
            AudioSettings.Instance.CanPlaySounds = !AudioSettings.Instance.CanPlaySounds;
        }

        [UsedImplicitly]
        public void MusicButtonPressed()
        {
            AudioSettings.Instance.CanPlayMusic = !AudioSettings.Instance.CanPlayMusic;
        }

        [UsedImplicitly]
        public void FullScreenButtonPressed()
        {
            Screen.fullScreen = !Screen.fullScreen;
        }

        [UsedImplicitly]
        public void GoBackButtonPressed()
        {
            PageSwitcher.Instance.Switch(this, mainPage);
        }
    }
}