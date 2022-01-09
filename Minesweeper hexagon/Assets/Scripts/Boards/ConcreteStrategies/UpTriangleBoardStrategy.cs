namespace Sweeper.Boards.ConcreteStrategies
{
    public class UpTriangleBoardStrategy : BoardStrategy
    {
        public override int GetColumnInRow(int row)
        {
            return RowCount - row;
        }

        public override int GetFirstColumnInRow(int row)
        {
            return 0;
        }
    }
}