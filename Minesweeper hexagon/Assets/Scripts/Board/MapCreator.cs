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
                Vector2Int randomPos = new Vector2Int(Random.Range(0, _gameBoard.RowCount + 1),
                    Random.Range(0, _gameBoard.RowCount + 1));
                GameTile currentTile = _gameBoard.GetCell(randomPos.x, randomPos.y);

                if (currentTile != null && currentTile.CurrentState != currentTile.MineState)
                {
                    currentTile.SetState(currentTile.MineState);
                    _placedMinePositions.Add(randomPos);
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