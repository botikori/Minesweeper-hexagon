using Sweeper.Core.Board;
using UnityEngine;

namespace Sweeper.Core.Tile.States
{
    public class NumberState : BaseState
    {
        public NumberState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites,
            BoardStrategy boardStrategy) : base(gameTile, spriteRenderer, tileSprites, boardStrategy)
        {
        }

        public int Number { get; set; } = 0;

        public override void RightClick()
        {
            base.RightClick();
            RevealNeighbours();
        }

        public override void Reveal()
        {
            if (IsFlagged || IsQuestioned) return;
            if (IsRevealed) { return; }
            
            base.Reveal();

            spriteRenderer.sprite = tileSprites.RevealedNumbers[Number - 1];
        }

        private void RevealNeighbours()
        {
            GameTile[] neighbours = gameBoard.GetNeighbours(gameTile.Col, gameTile.Row);
            
            if (HasEnoughFlaggedNeighbours(neighbours))
            {
                Debug.Log("has enough flags around it");
                foreach (var neighbour in neighbours)
                {
                    if (!neighbour.CurrentState.IsFlagged && !neighbour.CurrentState.IsQuestioned)
                    {
                        if (neighbour.CurrentState == neighbour.MineState && !neighbour.CurrentState.IsFlagged)
                        {
                            neighbour.MineState.MineRevealType = MineRevealType.WrongFlag;
                        }
                        
                        neighbour.CurrentState.Reveal();
                    }
                }
            }
        }

        private bool HasEnoughFlaggedNeighbours(GameTile[] neighbours)
        {
            int flaggedNeighbours = 0;

            foreach (var neighbour in neighbours)
            {
                if (neighbour.CurrentState.IsFlagged)
                {
                    flaggedNeighbours++;
                }
            }
            Debug.Log(flaggedNeighbours);

            if (flaggedNeighbours == Number) return true;
            return false;
        }
    }
}