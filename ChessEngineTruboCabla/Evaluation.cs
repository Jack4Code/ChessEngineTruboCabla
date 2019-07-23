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
            //count up the white values
            for (int i = 21; i < 99; i++)
            {
                if (board.BitBoard[i] == 1 && (i % 10 != 0 || i % 10 != 9))
                {
                    whiteValue += board.BitBoard[i] * GetPieceValue(board.Pieces[i]);
                }      
            }
            //count up the black values
            for (int i = 21; i < 99; i++)
            {
                if (board.BitBoard[i] == -1 && (i % 10 != 0 || i % 10 != 9))
                {
                    blackValue += board.BitBoard[i] * GetPieceValue(board.Pieces[i]);
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

        public static int[] PawnSquareTable = new int[64]
        {
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
            0,  0,  0,  0,  0,  0,  0,  0,
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



    }
}
