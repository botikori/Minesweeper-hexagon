using UnityEngine;

namespace Sweeper.Tile.States
{
    public class BaseState : IState
    {
        protected GameTile gameTile;
        protected bool isFlagged = false;
        protected bool isQuestioned = false;
        protected bool isRevealed = false;
        protected SpriteRenderer spriteRenderer;

        public BaseState(GameTile gameTile, SpriteRenderer spriteRenderer)
        {
            this.gameTile = gameTile;
            this.spriteRenderer = spriteRenderer;
        }

        public virtual void LeftClick()
        {
            //TODO set right sprites
            if (!isRevealed)
            {
                if (!isFlagged && !isQuestioned)
                {
                    isFlagged = true;
                }
                else if (isFlagged)
                {
                    isFlagged = false;
                    isQuestioned = true;
                }
                else
                {
                    isQuestioned = false;
                }
            }
        }

        public virtual void RightClick()
        {
            
        }
    }
}
