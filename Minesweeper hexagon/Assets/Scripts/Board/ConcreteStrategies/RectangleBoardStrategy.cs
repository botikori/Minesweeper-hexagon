using UnityEngine;

namespace Sweeper.Board.ConcreteStrategies
{
    public class RectangleBoardStrategy : BoardStrategy
    {
        protected override int GetColumnInRow(int row)
        {
            return RowCount;
        }

        protected override int GetFirstColumnInRow(int row)
        {
            return Mathf.FloorToInt(row / 2.0f) * -1;
        }
    }
}