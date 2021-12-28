using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sweeper.Tile.States
{
    public class MineState : BaseState
    {
        public MineState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites) : base(gameTile, spriteRenderer, tileSprites)
        {
        }
    }
}
