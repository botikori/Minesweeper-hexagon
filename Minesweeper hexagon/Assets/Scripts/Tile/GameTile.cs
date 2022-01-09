using System;
using UnityEngine;
using Sweeper.Tile.States;

namespace Sweeper.Tile
{
    public class GameTile : MonoBehaviour
    {
        public IState CurrentState { get; private set; }

        public EmptyState EmptyState { get; set; }
        public MineState MineState { get; set; }
        public NumberState NumberState { get; set; }
        
        public int Row { get; set; }
        public int Col { get; set; }

        private SpriteRenderer _spriteRenderer;
        private TileSprites _tileSprites;

        private void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _tileSprites = GetComponent<TileSprites>();

            EmptyState = new EmptyState(this, _spriteRenderer, _tileSprites);
            MineState = new MineState(this, _spriteRenderer, _tileSprites);
            NumberState = new NumberState(this, _spriteRenderer, _tileSprites);
        }

        private void Start()
        {
            SetState(EmptyState);
            GetComponentInChildren<TextMesh>().text = $"{Row}; {Col}";
        }

        private void OnMouseDown()
        {
            CurrentState.LeftClick();
        }

        public void SetState(IState newState)
        {
            if (newState != null)
            {
                CurrentState = newState;
            }
        }
    }
}