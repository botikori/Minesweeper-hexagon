using UnityEngine;

namespace Sweeper.Tile.States
{
    public class NumberState : BaseState
    {
        public int Number { get; set; } = 0;

        public override void Reveal()
        {
            base.Reveal();
            spriteRenderer.sprite = tileSprites.RevealedNumbers[Number - 1];
        }

        public NumberState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites) : base(gameTile, spriteRenderer, tileSprites)
        {
        }
    }
}
