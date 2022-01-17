using System;
using Sweeper.Core.Board;
using UnityEngine;

namespace Sweeper.Core.Tile.States
{
    public class MineState : BaseState
    {
        public static event Action BombExploded;

        public MineRevealType MineRevealType { get; set; } = MineRevealType.Default;
        
        public MineState(GameTile gameTile, SpriteRenderer spriteRenderer, TileSprites tileSprites,
            BoardStrategy boardStrategy) : base(gameTile, spriteRenderer, tileSprites, boardStrategy)
        {
        }

        public override void RightClick()
        {
            if (IsFlagged || IsQuestioned) return;
            MineRevealType = MineRevealType.Click;
            base.RightClick();
        }

        public override void Reveal()
        {
            if (IsFlagged || IsQuestioned) return;
            if (IsRevealed) { return; }
            
            base.Reveal();

            switch (MineRevealType)
            {
                case MineRevealType.Default:
                    spriteRenderer.sprite = tileSprites.RevealedMine;
                    break;
                case MineRevealType.Click:
                    spriteRenderer.sprite = tileSprites.RevealedMineDeath;
                    BombExploded?.Invoke();
                    break;
                case MineRevealType.WrongFlag:
                    spriteRenderer.sprite = tileSprites.RevealedMineFlag;
                    BombExploded?.Invoke();
                    break;
            }
        }
    }
}