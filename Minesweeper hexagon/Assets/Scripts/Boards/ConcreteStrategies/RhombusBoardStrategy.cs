namespace Sweeper.Boards.ConcreteStrategies
{
    public class RhombusBoardStrategy : BoardStrategy
    {
        public override int GetColumnInRow(int row)
        {
            return RowCount;
        }

        public override int GetFirstColumnInRow(int row)
        {
            return 0;
        }
    }
}