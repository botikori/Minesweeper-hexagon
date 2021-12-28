using UnityEngine;

namespace Sweeper
{
    public class TileSprites : MonoBehaviour
    {
        [SerializeField] private Sprite[] revealedNumbers;
        [SerializeField] private Sprite revealedMine;
        [SerializeField] private Sprite revealedEmpty;
        [SerializeField] private Sprite revealedMineDeath;
        [SerializeField] private Sprite revealedMineFlag;
        [SerializeField] private Sprite unrevealed;
        [SerializeField] private Sprite unrevealedFlag;
        [SerializeField] private Sprite unrevealedQuestion;

        public Sprite[] RevealedNumbers { get { return revealedNumbers; } }
        public Sprite RevealedMine { get { return revealedMine; } }
        public Sprite RevealedEmpty { get { return revealedEmpty; } }
        public Sprite RevealedMineDeath { get { return revealedMineDeath; } }
        public Sprite RevealedMineFlag { get { return revealedMineFlag; } }
        public Sprite Unrevealed { get { return unrevealed; } }
        public Sprite UnrevealedFlag { get { return unrevealedFlag; } }
        public Sprite UnrevealedQuestion { get { return unrevealedQuestion; } }
    }
}
