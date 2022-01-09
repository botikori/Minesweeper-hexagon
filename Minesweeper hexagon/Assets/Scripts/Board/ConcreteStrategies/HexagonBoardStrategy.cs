using UnityEngine;

namespace Sweeper.Board.ConcreteStrategies
{
    public class HexagonBoardStrategy : BoardStrategy
    {
        protected override int GetColumnInRow(int row)
        {
            return 2 * HalfRowCount + 1 - Mathf.Abs(HalfRowCount - row);
        }

        protected override int GetFirstColumnInRow(int row)
        {
            return HalfRowCount - row <= 0 ? 0 : HalfRowCount - row;
        }
        
        private int HalfRowCount
        {
            get { return Mathf.FloorToInt(RowCount / 2.0f); }
        }
    }
}