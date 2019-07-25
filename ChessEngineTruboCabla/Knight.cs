using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class Knight : Piece
    {
        public int Position { get; set; }
        public string Color { get; set; }
        public int[] PossibleMoves { get; set; }

        public override int[] HowPieceMoves => throw new NotImplementedException();

        public Knight(string color, int position)
        {
            Position = position;
            Color = color;
            DisplayChar = Color == "white" ? "N" : "n";
            Value = 300;

            SquareTable = new int[64]
            {
                -10, 0,  0,  0,  0,  0,  0,-10,
                 0,  0, 40, 40, 40, 40,  0,  0,
                 0,  0, 60, 80, 80, 60,  0,  0,
                 0,  0, 50, 70, 70, 50,  0,  0,
                 0,  0, 50, 70, 70, 50,  0,  0,
                 0,  0, 40, 40, 40, 40,  0,  0,
                 0,  0,  0, 30, 30,  0,  0,  0,
                -10, 0,  0,  0,  0,  0,  0,-10
            };
        }

        public override void FindAllPossibleMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
