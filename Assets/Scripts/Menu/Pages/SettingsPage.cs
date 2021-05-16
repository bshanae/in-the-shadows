using JetBrains.Annotations;
using UnityEngine;

namespace Menu
{
    public class SettingsPage : Page
    {
        [SerializeReference] private Page mainPage;

        [UsedImplicitly]
        public void SoundButtonPressed()
        {
            
        }

        [UsedImplicitly]
        public void MusicButtonPressed()
        {
            
        }

        [UsedImplicitly]
        public void GoBackButtonPressed()
        {
            PageSwitcher.Instance.Switch(this, mainPage);
        }
    }
}