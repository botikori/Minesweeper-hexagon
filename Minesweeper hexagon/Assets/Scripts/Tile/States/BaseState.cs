using UnityEngine;

namespace Sweeper.Tile.States
{
    public abstract class BaseState : IState
    {
        protected GameTile gameTile;
        protected bool isFlagged = false;
        protected bool isQuestioned = false;
        protected bool isRevealed = false;
        protected SpriteRenderer spriteRenderer;
        protected TileSprites tileSprites;

        public BaseState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites)
        {
            this.gameTile = gameTile;
            this.spriteRenderer = spriteRenderer;
            this.tileSprites = tileSprites;
        }

        public virtual void RightClick()
        {
            if (!isRevealed)
            {
                Reveal();
                return;
            }
        }

        public virtual void Reveal()
        {
        }

        public virtual void LeftClick()
        {
            if (!isRevealed)
            {
                if (!isFlagged && !isQuestioned)
                {
                    FlagCell();
                }
                else if (isFlagged)
                {
                    QuestionCell();
                }
                else
                {
                    RemoveQuestion();
                }
            }
        }

        private void FlagCell()
        {
            isFlagged = true;
            spriteRenderer.sprite = tileSprites.UnrevealedFlag;
        }

        private void QuestionCell()
        {
            isFlagged = false;
            isQuestioned = true;
            spriteRenderer.sprite = tileSprites.UnrevealedQuestion;
        }

        private void RemoveQuestion()
        {
            isQuestioned = false;
            spriteRenderer.sprite = tileSprites.UnrevealedQuestion;
        }
    }
}
