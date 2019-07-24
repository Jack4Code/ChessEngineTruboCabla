using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class Evaluation
    {
        private const int PawnValue = 100;
        private const int KnightValue = 300;
        private const int BishopValue = 320;
        private const int RookValue = 500;
        private const int QueenValue = 900;
        private const int KingValue = 100000;

        public static int EvaluateBoard(Board board)
        {
            int whiteValue = 0;
            int blackValue = 0;

            for (int i = 21; i < 99; i++)
            {
                //count up the white values
                if (board.BitBoard[i] == 1 && (i % 10 != 0 || i % 10 != 9))
                {
                    whiteValue += (board.BitBoard[i] * GetPieceValue(board.Pieces[i])) + GetPositionWeight(board.Pieces[i], (board.MapTo64[i]), board.PieceCntOnBoard);
                }
                //count up the black values
                if (board.BitBoard[i] == -1 && (i % 10 != 0 || i % 10 != 9))
                {
                    blackValue += (board.BitBoard[i] * GetPieceValue(board.Pieces[i])) - GetPositionWeight(board.Pieces[i], (board.MapTo64[i]), board.PieceCntOnBoard);
                }
            }
            return whiteValue + blackValue;
        }

        public static int GetPieceValue(Piece piece)
        {
            if (piece != null)
            {
                if (piece.GetType() == typeof(Pawn))
                {
                    return PawnValue;
                }
                else if (piece.GetType() == typeof(Rook))
                {
                    return RookValue;
                }
                else if (piece.GetType() == typeof(Knight))
                {
                    return KnightValue;
                }
                else if (piece.GetType() == typeof(Bishop))
                {
                    return BishopValue;
                }
                else if (piece.GetType() == typeof(Queen))
                {
                    return QueenValue;
                }
                else if (piece.GetType() == typeof(King))
                {
                    return KingValue;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public static int GetPositionWeight(Piece piece, int position, int pieceCnt)
        {
            //return o to turn off this heuristic
            if (piece != null)
            {
                if (piece.GetType() == typeof(Pawn))
                {
                    if (piece.Color == "white")
                    {
                        return PawnSquareTable[position];
                    }
                    else
                    {
                        return PawnSquareTable[63 - position];
                    }

                }
                else if (piece.GetType() == typeof(Rook))
                {
                    if (piece.Color == "white")
                    {
                        return RookSquareTable[position];
                    }
                    else
                    {
                        return RookSquareTable[63 - position];
                    }
                }
                else if (piece.GetType() == typeof(Knight))
                {
                    if (piece.Color == "white")
                    {
                        return KnightSquareTable[position];
                    }
                    else
                    {
                        return KnightSquareTable[63 - position];
                    }
                }
                else if (piece.GetType() == typeof(Bishop))
                {
                    if (piece.Color == "white")
                    {
                        return BishopSquareTable[position];
                    }
                    else
                    {
                        return BishopSquareTable[63 - position];
                    }
                }
                else if (piece.GetType() == typeof(Queen))
                {
                    if (piece.Color == "white")
                    {
                        return QueenSquareTable[position];
                    }
                    else
                    {
                        return QueenSquareTable[63 - position];
                    }
                }
                else if (piece.GetType() == typeof(King))
                {
                    if (piece.Color == "white")
                    {
                        return KingOpeningSquareTable[position];
                    }
                    else
                    {
                        return KingOpeningSquareTable[63 - position];
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private static int[] PawnSquareTable = new int[64]
        {
            0,  0,  0,  0,  0,  0,  0,  0,
            30, 40, 50, 60, 60, 50, 40, 30,
            20, 20, 40, 40, 40, 40, 20, 20,
            10, 10, 20, 30, 30, 20, 10, 10,
            10, 10, 10, 30, 30, 10, 10, 10,
            5,  10, 10, 20, 20, 10, 10, 5,
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0
        };



        private static int[] KnightSquareTable = new int[64]
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

        private static int[] BishopSquareTable = new int[64]
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

        private static int[] RookSquareTable = new int[64]
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

        private static int[] QueenSquareTable = new int[64]
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

        private static int[] KingOpeningSquareTable = new int[64]
        {
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
            100,100,0,  0,  0,  0,100,100
        };

        private static int[] KingEndGameSquareTable = new int[64]
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
}
