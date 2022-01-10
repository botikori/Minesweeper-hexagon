using Sweeper.Board;
using UnityEngine;

namespace Sweeper.Tile.States
{
    public class EmptyState : BaseState
    {
        public EmptyState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites, BoardStrategy boardStrategy) : base(gameTile, spriteRenderer, tileSprites, boardStrategy)
        {
        }

        public override void Reveal()
        {
            base.Reveal();
            spriteRenderer.sprite = tileSprites.RevealedEmpty;
            RevealNeighbours();
        }

        private void RevealNeighbours()
        {
            GameTile[] neighbours = gameBoard.GetNeighbours(gameTile.Col, gameTile.Row);

            foreach (var neighbour in neighbours)
            {
                if (!neighbour.CurrentState.IsRevealed)
                {
                    neighbour.CurrentState.Reveal();
                }
            }
        }
    }
}
