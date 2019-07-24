using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class Queen : Piece
    {
        public int Position { get; set; }
        public string Color { get; set; }
        public int[] PossibleMoves { get; set; }

        public override int[] HowPieceMoves => throw new NotImplementedException();

        public Queen(string color, int position)
        {
            Position = position;
            Color = color;
            DisplayChar = "Q";
            Value = 900;

            SquareTable = new int[64]
            {
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0,  0,  0,  0,  0,  0,  0,
                0, 20, 20, 20, 20, 20, 20,  0,
                0, 20, 20, 20, 20, 20, 20,  0,
                0, 20, 20, 20, 20, 20, 20,  0,
                0, 20, 20, 20, 20, 20, 20,  0,
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0,  0,  0,  0,  0,  0,  0
            };
        }

        public override void FindAllPossibleMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
