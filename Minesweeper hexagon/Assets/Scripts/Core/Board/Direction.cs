using UnityEngine;

namespace Sweeper.Core.Board
{
    public static class Direction
    {
        public static readonly Vector2Int[] NeighbourDirections =
        {
            new Vector2Int(-1, 0), 
            new Vector2Int(-1, 1),
            new Vector2Int(0, -1),
            new Vector2Int(0,1),
            new Vector2Int(1, -1),
            new Vector2Int(1, 0)
        };
    }
}