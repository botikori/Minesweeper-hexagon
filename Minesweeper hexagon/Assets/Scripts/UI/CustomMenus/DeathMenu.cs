using Sweeper.Core;
using Sweeper.Core.Tile.States;

namespace Sweeper.UI.CustomMenus
{
    public class DeathMenu : Menu<DeathMenu>
    {
        protected override void Awake()
        {
            base.Awake();
            MineState.BombExploded += OnBombExploded;
        }

        private void OnBombExploded()
        {
            Open();
        }

        public void OnRestartPressed()
        {
            LevelLoader.ReloadLevel();
            GameMenu.Open();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            MineState.BombExploded -= OnBombExploded;
        }
    }
}