namespace Sweeper.Boards
{
    public class RhombusBoard : BaseBoard
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