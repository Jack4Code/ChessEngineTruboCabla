using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class King : Piece
    {
        //public int Position { get; set; }
        //public string Color { get; set; }
        //public int[] PossibleMoves { get; set; }

        public override int[] HowPieceMoves { get { return new int[] { -11, -10, -9, -1, 1, 9, 10, 11 }; } }

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

            for(int i=0; i<HowPieceMoves.Length; i++)
            {
                //check for out of bounds?
                if (!(board.OutOfBoundsArea.ToList().IndexOf(Position + HowPieceMoves[i] * pieceColor * -1) != -1))
                {
                    //is square null
                    if(board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1] == null)
                    {
                        PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                    }
                    else if(board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1].Color != Color) //if the square is not empty, is it occupied by enemy piece?
                    {
                        PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                    }
                }
            }
            
        }
    }
}
