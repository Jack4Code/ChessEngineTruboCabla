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
            DisplayChar = Color == "white" ? "K" : "k";
            Value = 100000;

            OpeningSquareTable = new int[64]
            {
                  0,  0,  0,  0,  0,  0,  0,  0,
                  0,  0,  0,  0,  0,  0,  0,  0,
                  0,  0,  0,  0,  0,  0,  0,  0,
                  0,  0,  0,  0,  0,  0,  0,  0,
                  0,  0,  0,  0,  0,  0,  0,  0,
                  0,  0,  0,  0,  0,  0,  0,  0,
                  0,  0,  0,  0,  0,  0,  0,  0,
                100,100,  0,  0,  0,  0,100,100
            };

            EndGameSquareTable = new int[64]
            {
                -10,  -10,  -10,  -10,  -10,  -10,  -10,  -10,
                -10,  0,      0,    0,    0,    0,   0,   -10,
                -10,  0,     90,   90,   90,   90,   0,   -10,
                -10,  0,    100,  100,  100,  100, -10,   -10,
                -10,  0,    100,  100,  100,  100,   0,   -10,
                -10,  0,     90,   90,   90,   90,   0,   -10,
                -10,  0,      0,    0,    0,    0,   0,   -10,
                -10,  -10,  -10,  -10,  -10,  -10,  -10,  -10
            };
        }

        public override void FindAllPossibleMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
