using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    [Serializable]
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

            for (int i = 0; i < HowPieceMoves.Length; i++)
            {
                //check for out of bounds?
                if (!(board.OutOfBoundsArea.ToList().IndexOf(Position + HowPieceMoves[i] * pieceColor * -1) != -1))
                {
                    //is square null
                    if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1] == null)
                    {
                        //before adding it, call a function which will determine if the move will put the king in check. if so, don't add the move.
                        if (isLegalMove((HowPieceMoves[i] * pieceColor * -1) + Position, board, pieceColor))
                        {
                            PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                        }
                    }
                    else if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1].Color != Color) //if the square is not empty, is it occupied by enemy piece?
                    {
                        if (isLegalMove((HowPieceMoves[i] * pieceColor * -1) + Position, board, pieceColor))
                        {
                            PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                        }
                    }
                }
            }
        }

        public bool isLegalMove(int potentialMove, Board board, int pieceColor)
        {
            bool isLegal = true;
            //Board hypotheticalBoard = board.Copy();

            Board hypotheticalBoard = Utilities.DeepClone<Board>(board);

            hypotheticalBoard.Pieces[Position] = null;
            hypotheticalBoard.BitBoard[Position] = 0;
            hypotheticalBoard.Pieces[potentialMove] = new King(Color, potentialMove);
            hypotheticalBoard.BitBoard[potentialMove] = pieceColor;
            if (pieceColor == 1)
            {
                hypotheticalBoard.PositionOfWhiteKing = potentialMove;
            }
            else if (pieceColor == -1)
            {
                hypotheticalBoard.PositionOfBlackKing = potentialMove;
            }
            //loop through surrounding squares to make sure enemy king isn't near by
            int[] kingSquaresToExamine = new int[] { -11, -10, -9, -1, 1, 9, 10, 11 };
            for(int i=0; i<kingSquaresToExamine.Length; i++)
            {
                if(hypotheticalBoard.PositionOfWhiteKing + kingSquaresToExamine[i] == hypotheticalBoard.PositionOfBlackKing)
                {
                    isLegal = false;
                }
            }
            hypotheticalBoard.DetermineIfCheck();
            if (hypotheticalBoard.checkStatus == pieceColor)
            {
                isLegal = false;
            }

            return isLegal;
        }
    }
}
