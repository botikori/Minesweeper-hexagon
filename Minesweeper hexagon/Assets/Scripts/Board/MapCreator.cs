using Sweeper.Tile;
using UnityEngine;

namespace Sweeper.Board
{
    public class MapCreator : MonoBehaviour
    {
        private BoardStrategy _gameBoard;
        private int _mineCount;
        private int _placedMines;

        public void CreateMap(int mineCount, BoardStrategy gameBoard)
        {
            this._gameBoard = gameBoard;
            this._mineCount = mineCount;

            CreateMines();
        }

        private void CreateMines()
        {
            while (_placedMines != _mineCount)
            {
                Vector2Int randomPos = new Vector2Int(Random.Range(0, _gameBoard.RowCount + 1),
                    Random.Range(0, _gameBoard.RowCount + 1));
                GameTile currentTile = _gameBoard.GetCell(randomPos.x, randomPos.y);

                if (currentTile != null && currentTile.CurrentState == currentTile.EmptyState)
                {
                    currentTile.SetState(currentTile.MineState);
                    _placedMines++;
                    Debug.Log($"Mine added at: {randomPos.x}; {randomPos.y}");
                    RaiseNumbers(randomPos.x, randomPos.y);
                }
            }
        }

        private void RaiseNumbers(int x, int y)
        {
            GameTile[] neighbours = _gameBoard.GetNeighbours(x, y);

            foreach (var neighbour in neighbours)
            {
                if (neighbour.CurrentState != neighbour.NumberState) neighbour.SetState(neighbour.NumberState);
                neighbour.NumberState.Number++;
            }
        }
    }
}