using Sweeper.Board;
using UnityEngine;

namespace Sweeper.Tile.States
{
    public abstract class BaseState : IState
    {
        public bool IsFlagged { get; set; } = false;
        public bool IsQuestioned { get; set; } = false;

        public bool IsRevealed { get; set; } = false;

        protected GameTile gameTile;
        protected SpriteRenderer spriteRenderer;
        protected TileSprites tileSprites;
        protected BoardStrategy gameBoard;

        public BaseState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites,
            BoardStrategy boardStrategy)
        {
            this.gameTile = gameTile;
            this.spriteRenderer = spriteRenderer;
            this.tileSprites = tileSprites;
            this.gameBoard = boardStrategy;
        }

        public virtual void RightClick()
        {
            if (IsFlagged || IsQuestioned) return;
            
            if (!IsRevealed)
            {
                Reveal();
            }
        }


        public virtual void Reveal()
        {
            IsRevealed = true;
        }

        public virtual void LeftClick()
        {
            if (!IsRevealed)
            {
                if (!IsFlagged && !IsQuestioned)
                {
                    FlagCell();
                }
                else if (IsFlagged)
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
            IsFlagged = true;
            spriteRenderer.sprite = tileSprites.UnrevealedFlag;
        }

        private void QuestionCell()
        {
            IsFlagged = false;
            IsQuestioned = true;
            spriteRenderer.sprite = tileSprites.UnrevealedQuestion;
        }

        private void RemoveQuestion()
        {
            IsQuestioned = false;
            spriteRenderer.sprite = tileSprites.Unrevealed;
        }
    }
}