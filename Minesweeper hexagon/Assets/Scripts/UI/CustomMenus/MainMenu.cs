using System.Collections;
using Sweeper.UI.Utilities;
using UnityEngine;

namespace Sweeper.UI.CustomMenus
{
    public class MainMenu : Menu<MainMenu>
    {
        [SerializeField] private float loadGameDelay = 0.5f;
        [SerializeField] private TransitionFader transitionFader;
        
        public void OnPlayPressed()
        {
            StartCoroutine(OnPlayPressedRoutine());
        }

        private IEnumerator OnPlayPressedRoutine()
        {
            TransitionFader.PlayTransition(transitionFader);
            LevelLoader.LoadNextLevel();
            yield return new WaitForSeconds(loadGameDelay);
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