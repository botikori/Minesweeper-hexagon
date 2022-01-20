using System.Collections;
using Sweeper.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sweeper.UI.CustomMenus
{
    public class MainMenu : Menu<MainMenu>
    {
        [SerializeField] private float screenFadeDelay = 0.2f;

        protected override void Awake()
        {
            base.Awake();
            SceneManager.sceneLoaded += OnSceneLoaded;
            ScreenFade.FadedIn += OnFadedIn;
            
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Game")
            {
                ScreenFade.Instance.FadeOut(screenFadeDelay);
            }
        }

        public void OnFadedIn()
        {
            LevelLoader.LoadNextLevel();
            GameMenu.Open();
        }

        public void OnPlayPressed()
        {
            ScreenFade.Instance.FadeIn(screenFadeDelay);
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
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            SceneManager.sceneLoaded -= OnSceneLoaded;
            ScreenFade.FadedIn -= OnFadedIn;
        }
    }
}