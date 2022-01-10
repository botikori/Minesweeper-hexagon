using Sweeper.Board;
using UnityEngine;

namespace Sweeper.Tile.States
{
    public class MineState : BaseState
    {
        public MineState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites, BoardStrategy boardStrategy) : base(gameTile, spriteRenderer, tileSprites, boardStrategy)
        {
        }

        public override void Reveal()
        {
            base.Reveal();
            spriteRenderer.sprite = tileSprites.RevealedMine;
        }
    }
}
