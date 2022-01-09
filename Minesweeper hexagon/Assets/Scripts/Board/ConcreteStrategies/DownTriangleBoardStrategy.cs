namespace Sweeper.Board.ConcreteStrategies
{
    public class DownTriangleBoardStrategy : BoardStrategy
    {
        protected override int GetColumnInRow(int row)
        {
            return row + 1;
        }

        protected override int GetFirstColumnInRow(int row)
        {
            return RowCount - 1 - row;
        }
    }
}