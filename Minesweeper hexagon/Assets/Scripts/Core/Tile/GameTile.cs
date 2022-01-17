using Sweeper.Core.Board;
using Sweeper.Core.Tile.States;
using UnityEngine;

namespace Sweeper.Core.Tile
{
    public class GameTile : MonoBehaviour
    {
        public BaseState CurrentState { get; private set; }

        public EmptyState EmptyState { get; private set; }
        public MineState MineState { get; private set; }
        public NumberState NumberState { get; private set; }
        
        public int Row { get; set; }
        public int Col { get; set; }

        private SpriteRenderer _spriteRenderer;
        private TileSprites _tileSprites;
        private BoardStrategy _gameBoard;

        private void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _tileSprites = GetComponent<TileSprites>();
            _gameBoard = FindObjectOfType<BoardStrategy>();
            
            EmptyState = new EmptyState(this, _spriteRenderer, _tileSprites, _gameBoard);
            MineState = new MineState(this, _spriteRenderer, _tileSprites, _gameBoard);
            NumberState = new NumberState(this, _spriteRenderer, _tileSprites, _gameBoard);
            
            SetState(EmptyState);
        }

        private void Start()
        {
            TextMesh textMesh = GetComponentInChildren<TextMesh>();
            
            if (textMesh != null)
            {
                textMesh.text = $"{Row}; {Col}";    
            }
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

        public void SetState(BaseState newState)
        {
            if (newState != null)
            {
                CurrentState = newState;
            }
        }
    }
}