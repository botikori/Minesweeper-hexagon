using Sweeper.Core.Board;
using Sweeper.Core.Board.ConcreteStrategies;
using Sweeper.Core.Tile;
using Sweeper.Core.Tile.States;
using UnityEngine;

namespace Sweeper.Core
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private GameObject boardPrefab;
        [SerializeField] private GameTile gameTile;

        private BoardStrategy _boardStrategy;
        private MapCreator _mapCreator;

        private void Start()
        {
            _boardStrategy = boardPrefab.AddComponent<HexagonBoardStrategy>();
            _boardStrategy.CreateBoard(11, gameTile);
            
            _mapCreator = boardPrefab.GetComponent<MapCreator>();
            _mapCreator.CreateMap(17, _boardStrategy);

            GameTile[] gameTiles = FindObjectsOfType<GameTile>();

            MineState.BombExploded += GameOver;
            MapCreator.AllFlagged += GameWon;
            
            Camera.main.transform.position = _boardStrategy.CalculateCenter();
        }

        private void OnDestroy()
        {
            MineState.BombExploded -= GameOver;
            MapCreator.AllFlagged -= GameWon;
        }

        private void GameOver()
        {
              RevealAll();
        }

        private void GameWon()
        {
            RevealAll();
        }

        private void RevealAll()
        {
            foreach (var cell in _boardStrategy.AllTiles)
            {
                cell.CurrentState.Reveal();
            }
        }
    }
}