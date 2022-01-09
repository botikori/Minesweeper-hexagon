namespace Sweeper.Board.ConcreteStrategies
{
    public class RhombusBoardStrategy : BoardStrategy
    {
        protected override int GetColumnInRow(int row)
        {
            return RowCount;
        }

        protected override int GetFirstColumnInRow(int row)
        {
            return 0;
        }
    }
}