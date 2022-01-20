using System.Collections;
using Sweeper.Core;
using UnityEngine;

namespace Sweeper.UI.CustomMenus
{
    public class MainMenu : Menu<MainMenu>
    {
        [SerializeField] private float loadGameDelay = 0.5f;

        public void OnPlayPressed()
        {
            LevelLoader.LoadNextLevel();
            GameMenu.Open();
        }

        public void OnSettingsPressed()
        {
            SettingsMenu.Open();
        }

        public void OnCreditsPressed()
        {
            CreditsMenu.Open();
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }
    }
}