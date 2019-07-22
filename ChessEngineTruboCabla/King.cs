using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class King : Piece
    {
        public int Position { get; set; }
        public string Color { get; set; }
        public int[] PossibleMoves { get; set; }

        public override int[] HowPieceMoves => throw new NotImplementedException();

        public King(string color, int position)
        {
            Position = position;
            Color = color;
        }

        public override void FindAllPossibleMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
