using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class Knight : Piece
    {
        //public int Position { get; set; }
        //public string Color { get; set; }
        //public int[] PossibleMoves { get; set; }

        public override int[] HowPieceMoves { get { return new int[] { -21, -19, -12, -8, 8, 12, 19, 21 }; } }

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
            PossibleMoves = new List<int>();
            int pieceColor = 0;
            if (Color == "white")
            {
                pieceColor = 1;
            }
            else
            {
                pieceColor = -1;
            }

            for (int i = 0; i < HowPieceMoves.Length; i++)
            {
                //check for out of bounds?
                if (!(board.OutOfBoundsArea.ToList().IndexOf(Position + HowPieceMoves[i] * pieceColor * -1) != -1))
                {
                    //is square null
                    if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1] == null)
                    {
                        PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                    }
                    else if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1].Color != Color) //if the square is not empty, is it occupied by enemy piece?
                    {
                        PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                    }
                }
            }

        }
    }
}
