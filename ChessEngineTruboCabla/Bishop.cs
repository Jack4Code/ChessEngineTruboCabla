using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class Bishop : Piece
    {
        public int Position { get; set; }
        public string Color { get; set; }
        public int[] PossibleMoves { get; set; }

        public override int[] HowPieceMoves => throw new NotImplementedException();

        public Bishop(string color, int position)
        {
            Position = position;
            Color = color;
            DisplayChar = "B";
            Value = 320;

            SquareTable = new int[64]
            {
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0, 60,  0,  0, 60,  0,  0,
                0, 50,  0, 40, 40,  0, 50,  0,
                0, 70,  0,  0,  0,  0, 70,  0,
                0,  0,  0,  0,  0,  0,  0,  0
            };
        }

        public override void FindAllPossibleMoves(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
