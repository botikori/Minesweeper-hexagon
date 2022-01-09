namespace Sweeper.Board.ConcreteStrategies
{
    public class DownTriangleBoardStrategy : BoardStrategy
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