using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public abstract class Piece
    {
        public int Position { get; set; }
        public string Color { get; protected set; }
        public string DisplayChar { get; protected set; }
        public int Value { get; protected set; }
        public int[] SquareTable { get; protected set; }
        public int[] OpeningSquareTable { get; protected set; }
        public int[] EndGameSquareTable { get; protected set; }
        public List<int> PossibleMoves { get; protected set; }

        public abstract int[] HowPieceMoves { get; }

        public abstract void FindAllPossibleMoves(Board board);

        public int GetSquareTableWeight(int position, bool isEndGame = false)
        {
            int[] sTable = null;
            if (SquareTable != null)
            {
                sTable = SquareTable;
            }
            else if (!isEndGame)
            {
                sTable = OpeningSquareTable;
            }
            else
            {
                sTable = EndGameSquareTable;
            }
            return sTable[Color == "white" ? position : 63 - position];
        }
    }
}
