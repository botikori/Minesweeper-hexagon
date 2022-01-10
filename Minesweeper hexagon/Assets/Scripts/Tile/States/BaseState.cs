using Sweeper.Board;
using UnityEngine;

namespace Sweeper.Tile.States
{
    public abstract class BaseState : IState
    {
        
        protected bool isFlagged = false;
        protected bool isQuestioned = false;
        
        public bool IsRevealed { get; set; } = false;
        
        protected GameTile gameTile;
        protected SpriteRenderer spriteRenderer;
        protected TileSprites tileSprites;
        protected BoardStrategy gameBoard;
        
        public BaseState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites, BoardStrategy boardStrategy)
        {
            this.gameTile = gameTile;
            this.spriteRenderer = spriteRenderer;
            this.tileSprites = tileSprites;
            this.gameBoard = boardStrategy;
        }

        public virtual void RightClick()
        {
            if (!IsRevealed)
            {
                Reveal();
                return;
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
            spriteRenderer.sprite = tileSprites.Unrevealed;
        }
    }
}
