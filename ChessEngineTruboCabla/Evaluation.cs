using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class Evaluation
    {
        public static int EvaluateBoard(Board board)
        {
            int whiteValue = 0;
            int blackValue = 0;
            int checkMateStatus = 0;

            if (board.checkMateStatus == 1)
            {
                checkMateStatus = 1000000;
            }
            else if (board.checkMateStatus == -1)
            {
                checkMateStatus = -1000000;
            }

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
            return whiteValue + blackValue + checkMateStatus;
        }

        public static int GetPieceValue(Piece piece)
        {
            return piece != null ? piece.Value : 0;
        }

        public static int GetPositionWeight(Piece piece, int position, int pieceCnt)
        {
            const int ENDGAME_PIECE_LIMIT = 10; //TODO: use pieceCnt to determine if we are in endgame
            return piece != null ? piece.GetSquareTableWeight(position, pieceCnt <= ENDGAME_PIECE_LIMIT) : 0;
        }
    }
}
