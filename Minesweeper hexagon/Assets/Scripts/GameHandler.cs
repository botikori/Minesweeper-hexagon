using System;
using Sweeper.Board;
using Sweeper.Board.ConcreteStrategies;
using Sweeper.Tile;
using Sweeper.Tile.States;
using UnityEngine;

namespace Sweeper
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
            
            Camera.main.transform.position = _boardStrategy.CalculateCenter();
        }

        private void OnDestroy()
        {
            MineState.BombExploded -= GameOver;
        }

        private void GameOver()
        {
            foreach (var cell in _boardStrategy.AllTiles)
            {
                cell.CurrentState.Reveal();
            }    
        }
    }
}