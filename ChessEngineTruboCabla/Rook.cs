using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class Rook : Piece
    {
        public int Position { get; set; }
        public string Color { get; set; }
        public int[] PossibleMoves { get; set; }

        public override int[] HowPieceMoves => throw new NotImplementedException();

        public Rook(string color, int position)
        {
            Position = position;
            Color = color;
            DisplayChar = Color == "white" ? "R" : "r";
            Value = 500;

            SquareTable = new int[64]
            {
                0,  0,  0,  0,  0,  0,  0,  0,
                0,100,100,100,100,100,100,  0,
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0,  0,  0,  0,  0,  0,  0,
                90,90, 90, 90, 90, 90, 90, 90,
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0, 90, 90, 90, 90,  0,  0
            };
        }

        public override void FindAllPossibleMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
