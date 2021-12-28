using UnityEngine;

namespace Sweeper.Tile
{
    public class GameTile : MonoBehaviour
    {
        public void OnMouseDown()
        {
            Destroy(gameObject);
        }
    }
}