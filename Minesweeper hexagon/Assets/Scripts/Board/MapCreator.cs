using System.Collections.Generic;
using Sweeper.Tile;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Sweeper.Board
{
    public class MapCreator : MonoBehaviour
    {
        private BoardStrategy _gameBoard;
        private int _mineCount;
        private int _placedMines;
        private List<Vector2Int> _placedMinePositions;

        private void Awake()
        {
            _placedMinePositions = new List<Vector2Int>();
        }

        public void CreateMap(int mineCount, BoardStrategy gameBoard)
        {
            this._gameBoard = gameBoard;
            this._mineCount = mineCount;

            CreateMines();

            foreach (var minePosition in _placedMinePositions)
            {
                RaiseNumbers(minePosition.x, minePosition.y);
            }
        }

        private void CreateMines()
        {
            while (_placedMines != _mineCount)
            {
                GameTile randomTile = _gameBoard.AllTiles[Random.Range(0, _gameBoard.AllTiles.Count)];

                if (randomTile.CurrentState != randomTile.MineState)
                {
                    randomTile.SetState(randomTile.MineState);
                    _placedMinePositions.Add(new Vector2Int(randomTile.Col, randomTile.Row));
                    _placedMines++;
                }
            }
        }

        private void RaiseNumbers(int x, int y)
        {
            GameTile[] neighbours = _gameBoard.GetNeighbours(x, y);

            foreach (var neighbour in neighbours)
            {
                if (neighbour.CurrentState == neighbour.EmptyState) neighbour.SetState(neighbour.NumberState);
                if (neighbour.CurrentState == neighbour.NumberState) neighbour.NumberState.Number++;
            }
        }
    }
}