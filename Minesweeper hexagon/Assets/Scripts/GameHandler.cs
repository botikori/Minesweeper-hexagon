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
        private MapCreator _mapCreator;
        
        private void Start()
        {
            _boardStrategy = boardPrefab.AddComponent<RectangleBoardStrategy>();
            _boardStrategy.CreateBoard(11, gameTile);
            
            _mapCreator = boardPrefab.GetComponent<MapCreator>();
            _mapCreator.CreateMap(5, _boardStrategy);

            GameTile[] gameTiles = FindObjectsOfType<GameTile>();

            Camera.main.transform.position = _boardStrategy.CalculateCenter();
        }
    }
}