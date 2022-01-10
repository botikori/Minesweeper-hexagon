using System;
using UnityEngine;
using Sweeper.Tile.States;

namespace Sweeper.Tile
{
    public class GameTile : MonoBehaviour
    {
        public IState CurrentState { get; private set; }

        public EmptyState EmptyState { get; private set; }
        public MineState MineState { get; private set; }
        public NumberState NumberState { get; private set; }
        
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
            
            SetState(EmptyState);
        }

        private void OnMouseDown()
        {
            CurrentState.RightClick();
        }

        private void Update()
        {
            DetectLeftClick();
        }

        private void DetectLeftClick()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetInstanceID() == gameObject.GetInstanceID())
                    {
                        CurrentState.LeftClick();
                    }
                }
            }
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