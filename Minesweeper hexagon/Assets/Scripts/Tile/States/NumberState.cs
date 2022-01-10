using Sweeper.Board;
using UnityEngine;

namespace Sweeper.Tile.States
{
    public class NumberState : BaseState
    {
        public NumberState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites, BoardStrategy boardStrategy) : base(gameTile, spriteRenderer, tileSprites, boardStrategy)
        {
        }

        public int Number { get; set; } = 0;

        public override void Reveal()
        {
            base.Reveal();
            spriteRenderer.sprite = tileSprites.RevealedNumbers[Number - 1];
        }

    }
}
