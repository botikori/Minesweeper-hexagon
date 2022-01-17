namespace Sweeper.Core.Tile.States
{
    public interface IState
    {
        void LeftClick();
        void RightClick();
        void Reveal();      
    }
}
