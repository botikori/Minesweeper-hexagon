using UnityEngine;

namespace Sweeper.Boards
{
    public class DownTriangleBoard : BaseBoard
    {
        public override int GetColumnInRow(int row)
        {
            return row + 1;
        }

        public override int GetFirstColumnInRow(int row)
        {
            return RowCount - 1 - row;
        }
    }
}