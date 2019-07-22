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
        public List<int> PossibleMoves { get; protected set; }

        public abstract int[] HowPieceMoves { get; }

        public abstract void FindAllPossibleMoves(Board board);

    }
}
