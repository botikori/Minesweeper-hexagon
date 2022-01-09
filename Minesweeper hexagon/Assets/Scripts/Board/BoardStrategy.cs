using System.Collections.Generic;
using System.Linq;
using Sweeper.Tile;
using UnityEngine;

namespace Sweeper.Board
{
    public abstract class BoardStrategy : MonoBehaviour
    {
        private Dictionary<int, GameTile[]> _gameBoard;
        private GameTile _gameTile;
        
        protected int RowCount = 11;

        protected abstract int GetColumnInRow(int row);
        protected abstract int GetFirstColumnInRow(int row);

        private void Awake()
        {
            _gameBoard = new Dictionary<int, GameTile[]>();
        }

        public void CreateBoard(int rowCount, GameTile gameTile)
        {
            this.RowCount = rowCount;
            this._gameTile = gameTile;
            
            for (int y = 0; y < RowCount; y++)
            {
                int columnCount = GetColumnInRow(y);
                GameTile[] column = new GameTile[columnCount];

                for (int x = 0; x < columnCount; x++)
                {
                    column[x] = CreateTile(x + GetFirstColumnInRow(y), y);
                }

                _gameBoard.Add(y, column);
            }
        }

        public GameTile[] GetNeighbours(int x, int y)
        {
            if (!PositionExists(x,y))
            {
                return new GameTile[0];
            }

            List<GameTile> neighbourGameTiles = new List<GameTile>();

            foreach (var direction in Direction.NeighbourDirections)
            {
                GameTile currentCell = GetCell(x + direction.x, y + direction.y);
                if (currentCell != null) neighbourGameTiles.Add(currentCell);
            }

            return neighbourGameTiles.ToArray();
        }
        
        public Vector3 CalculateCenter()
        {
            GameTile[] centerTiles =
                _gameBoard.FirstOrDefault(x => x.Key == Mathf.FloorToInt(_gameBoard.Count / 2.0f)).Value;
            GameTile centerTile = centerTiles[Mathf.FloorToInt(centerTiles.Length / 2.0f)];
            return new Vector3(centerTile.transform.position.x, centerTile.transform.position.y, -10);
        }

        public GameTile GetCell(int x, int y)
        {
            if (PositionExists(x, y)) return _gameBoard[y].ToList().Find(v => v.Col == x);
            return null;
        }

        private bool PositionExists(int x, int y)
        {
            if (y >= 0 && y < _gameBoard.Count)
            {
                List<GameTile> values = _gameBoard[y].ToList();

                if (x >= values.Min(c => c.Col) && x <= values.Max(c => c.Col))
                {
                    return true;
                }
            }
            return false;
        }

        private GameTile CreateTile(int x, int y)
        {
            GameTile tile = Instantiate(_gameTile, CalculateHexPosition(x, y),
                Quaternion.identity, transform);
            tile.Row = y;
            tile.Col = x;
            return tile;
        }

        private Vector3 CalculateHexPosition(int x, int y)
        {
            float smallRadius = Mathf.Cos(30.0f * Mathf.Deg2Rad);
            return new Vector3((x * smallRadius) + (y * smallRadius / 2), y * (3.0f / 4.0f), 0);
        }
    }
}