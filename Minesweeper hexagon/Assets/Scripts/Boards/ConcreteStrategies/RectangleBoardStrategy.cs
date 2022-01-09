using UnityEngine;

namespace Sweeper.Boards.ConcreteStrategies
{
    public class RectangleBoardStrategy : BoardStrategy
    {
        public override int GetColumnInRow(int row)
        {
            return RowCount;
        }

        public override int GetFirstColumnInRow(int row)
        {
            return Mathf.FloorToInt(row / 2.0f) * -1;
        }
    }
}