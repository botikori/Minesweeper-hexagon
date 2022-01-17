namespace Sweeper.Core.Board.ConcreteStrategies
{
    public class UpTriangleBoardStrategy : BoardStrategy
    {
        protected override int GetColumnInRow(int row)
        {
            return RowCount - row;
        }

        protected override int GetFirstColumnInRow(int row)
        {
            return 0;
        }
    }
}