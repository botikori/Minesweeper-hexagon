using System.Collections.Generic;
using System.Linq;
using Sweeper.Tile;
using UnityEngine;

namespace Sweeper.Boards
{
    public abstract class BoardStrategy : MonoBehaviour
    {
        public Dictionary<int, GameTile[]> GameBoard { get; private set; }
        
        [SerializeField] private GameTile gameTile;
        protected int RowCount = 11;

        public abstract int GetColumnInRow(int row);
        public abstract int GetFirstColumnInRow(int row);

        private void Awake()
        {
            GameBoard = new Dictionary<int, GameTile[]>();
        }

        private void Start()
        {
            CreateBoard();
            Camera.main.transform.position = CalculateCenter();
        }

        public void CreateBoard()
        {
            for (int y = 0; y < RowCount; y++)
            {
                int columnCount = GetColumnInRow(y);
                GameTile[] column = new GameTile[columnCount];

                for (int x = 0; x < columnCount; x++)
                {
                    column[x] = CreateTile(x  + GetFirstColumnInRow(y), y);
                }

                GameBoard.Add(y, column);
            }
        }
        public Vector3 CalculateCenter()
        {
            GameTile[] centerTiles = GameBoard.FirstOrDefault(x => x.Key == Mathf.FloorToInt(GameBoard.Count / 2.0f)).Value;
            GameTile centerTile = centerTiles[Mathf.FloorToInt(centerTiles.Length / 2.0f)];
            centerTile.GetComponentInChildren<SpriteRenderer>().color = Color.green;
            return new Vector3(centerTile.transform.position.x, centerTile.transform.position.y, -10);
        }

        private GameTile CreateTile(int x, int y)
        {
            GameTile tile = Instantiate(gameTile, CalculateHexPosition(x, y),
                Quaternion.identity, transform);
            tile.Row = y;
            tile.Col = x;
            return tile;
        }

        private Vector3 CalculateHexPosition(int x, int y)
        {
            float smallRadius = Mathf.Cos(30.0f * Mathf.Deg2Rad);
            return new Vector3((x * smallRadius) + (y * smallRadius / 2), y * (3.0f/4.0f), 0);
        }
    }
}
