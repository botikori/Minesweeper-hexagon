using UnityEngine;

namespace Sweeper
{
    public class HexagonBoard : BaseBoard
    {
        private int N
        {
            get { return Mathf.FloorToInt(RowCount / 2.0f); }
        }

        public override int GetColumnInRow(int row)
        {
            return 2 * N + 1 - Mathf.Abs(N - row);
        }

        public override int GetFirstColumnInRow(int row)
        {
            return N - row <= 0 ? 0 : N - row;
        }
    }
}