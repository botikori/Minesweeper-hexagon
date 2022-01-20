using Sweeper.Core;
using Sweeper.UI.Utilities;
using UnityEngine;

namespace Sweeper.UI.CustomMenus
{
    public class LevelCompleteMenu : Menu<LevelCompleteMenu>
    {
        public void OnNextLevelPressed()
        {
            base.OnBackPressed();
            LevelLoader.LoadNextLevel();
        }

        public void OnRestartPressed()
        {
            base.OnBackPressed();
            LevelLoader.ReloadLevel();
        }

        public void OnMainMenuPressed()
        {
            LevelLoader.LoadMainMenu();
            MainMenu.Open();
        }
    }
}