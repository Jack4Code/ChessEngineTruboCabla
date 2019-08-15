using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    [Serializable]
    public class Pawn : Piece
    {
        //Class Specific Variables
        public int MultipleSquareMoves = 1; //7; for queen
        public override int[] HowPieceMoves { get { return new int[] { 20, 10, 9, 11 }; } }

        //Constructors
        public Pawn() { }

        public Pawn(string color, int position)
        {
            Position = position;
            Color = color;
            DisplayChar = Color == "white" ? "P": "p";
            Value = 100;

            SquareTable = new int[64]
                {
                     0,  0,  0,  0,  0,  0,  0,  0,
                    30, 40, 50, 60, 60, 50, 40, 30,
                    20, 20, 40, 40, 40, 40, 20, 20,
                    10, 10, 20, 30, 30, 20, 10, 10,
                    10, 10, 10, 30, 30, 10, 10, 10,
                     5, 10, 10, 20, 20, 10, 10,  5,
                     0,  0,  0,  0,  0,  0,  0,  0,
                     0,  0,  0,  0,  0,  0,  0,  0
                };
        }

        public override void FindAllPossibleMoves(Board board)
        {
            int pieceColor = 0;
            if (Color == "white")
            {
                pieceColor = 1;
            }
            else
            {
                pieceColor = -1;
            }


            PossibleMoves = new List<int>();
            if (Position.ToString().Substring(0, 1) == "8" || Position.ToString().Substring(0, 1) == "3")
            {
                for (int i = 0; i < HowPieceMoves.Length; i++)
                {
                    if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1] == null && !(board.OutOfBoundsArea.ToList().IndexOf(Position + HowPieceMoves[i] * pieceColor * -1) != -1))
                    {
                        if(HowPieceMoves[i] == 10 || HowPieceMoves[i] == 20)
                        {
                            //PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                            if (isLegalMove((HowPieceMoves[i] * pieceColor * -1) + Position, board, pieceColor))
                            {
                                PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                            }
                        }  
                    }
                    if (!(board.OutOfBoundsArea.ToList().IndexOf(Position + HowPieceMoves[i] * pieceColor * -1) != -1))
                    {
                        if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1] != null && HowPieceMoves[i] != 10 && HowPieceMoves[i] != 20)
                        {
                            if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1].Color != Color)
                            {
                                //PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                                if (isLegalMove((HowPieceMoves[i] * pieceColor * -1) + Position, board, pieceColor))
                                {
                                    PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                                }
                            }
                        } 
                    }
                }
            }
            else
            {
                for (int i = 1; i < HowPieceMoves.Length; i++)
                {
                    //if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1] == null && !(board.OutOfBoundsArea.ToList().IndexOf(Position + HowPieceMoves[i] * pieceColor * -1) != -1))
                    //{
                    //    PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                    //}
                    if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1] == null && !(board.OutOfBoundsArea.ToList().IndexOf(Position + HowPieceMoves[i] * pieceColor * -1) != -1))
                    {
                        if (HowPieceMoves[i] == 10 || HowPieceMoves[i] == 20)
                        {
                            //PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                            if (isLegalMove((HowPieceMoves[i] * pieceColor * -1) + Position, board, pieceColor))
                            {
                                PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                            }
                        }
                    }
                    if (!(board.OutOfBoundsArea.ToList().IndexOf(Position + HowPieceMoves[i] * pieceColor * -1) != -1))
                    {
                        if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1] != null && HowPieceMoves[i] != 10 && HowPieceMoves[i] != 20)
                        {
                            if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1].Color != Color)
                            {
                                if (isLegalMove((HowPieceMoves[i] * pieceColor * -1) + Position, board, pieceColor))
                                {
                                    PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                                }
                            }
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
            hypotheticalBoard.Pieces[potentialMove] = new Queen(Color, potentialMove);
            hypotheticalBoard.BitBoard[potentialMove] = pieceColor;
            hypotheticalBoard.DetermineIfCheck();
            if (hypotheticalBoard.checkStatus == pieceColor)
            {
                isLegal = false;
            }

            return isLegal;
        }

    }
}
