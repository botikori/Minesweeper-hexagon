using UnityEngine;

namespace Sweeper.Tile.States
{
    public class EmptyState : BaseState
    {
        public EmptyState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites) : base(gameTile, spriteRenderer, tileSprites)
        {
        }

        public override void Reveal()
        {
            base.Reveal();
            spriteRenderer.sprite = tileSprites.RevealedEmpty;
        }
    }
}
