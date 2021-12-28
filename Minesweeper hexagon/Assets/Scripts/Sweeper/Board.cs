using System.Collections.Generic;
using UnityEngine;
using Sweeper.Tile;

namespace Sweeper
{
    public class Board : MonoBehaviour
    {
        public GameTile[,] GameBoard { get; set; }

        [SerializeField] private int width = 6;
        [SerializeField] private int height = 6;
        [SerializeField] private GameTile gameTile;

        public Vector3 Center { get {return CalculateCenter();}}

        private void Start()
        {
            CreateBoard();
            Camera.main.transform.position = new Vector3(Center.x, Center.y, -10);
        }

        public void CreateBoard()
        {
            GameBoard = new GameTile[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    GameBoard[x, y] = CreateTile(x, y);
                }
            }
        }

        public GameTile[] GetNeighbours(int x, int y)
        {
            List<GameTile> tiles = new List<GameTile>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i != 0 && j != 0)
                    {
                        tiles.Add(GameBoard[x + i, y + j]);  
                    }
                }
            }
            
            return tiles.ToArray();
        }

        private Vector3 CalculateCenter()
        {
            GameTile CenterTile = GameBoard[Mathf.FloorToInt(width / 2),
                 Mathf.FloorToInt(height / 2)];
            CenterTile.GetComponentInChildren<SpriteRenderer>().color = new Color(255, 0, 0);
            return CenterTile.transform.position;
        }

        private GameTile CreateTile(int x, int y)
        {
            GameTile tile = Instantiate(gameTile, CalculateHexPosition(x, y),
                Quaternion.identity, transform);
            return tile;
        }

        private Vector3 CalculateHexPosition(int x, int y)
        {
            Debug.Log(3 / 4);
            float R = Mathf.Cos(30 * Mathf.Deg2Rad);
            return new Vector3((x * R) + (y * R / 2), y * (3.0f/4.0f), 0);
        }
    }
}
