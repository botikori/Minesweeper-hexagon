using Sweeper.Board;
using Sweeper.Board.ConcreteStrategies;
using Sweeper.Tile;
using UnityEngine;

namespace Sweeper
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private GameObject boardPrefab;
        [SerializeField] private GameTile gameTile;

        private BoardStrategy _boardStrategy;
        
        private void Start()
        {
            _boardStrategy = boardPrefab.AddComponent<HexagonBoardStrategy>();
            _boardStrategy.CreateBoard(11, gameTile);
            Camera.main.transform.position = _boardStrategy.CalculateCenter();
        }
    }
}