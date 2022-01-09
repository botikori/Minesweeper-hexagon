namespace Sweeper.Boards
{
    public class UpTriangleBoard : BaseBoard
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