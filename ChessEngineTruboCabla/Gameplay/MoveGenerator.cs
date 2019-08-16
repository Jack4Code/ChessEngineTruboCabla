using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla.Gameplay
{
    public static class MoveGenerator
    {
        public static string MakeBestMove(Board board, int ply)
        {
            string bestMove = "";
            int bestMoveValue = Evaluation.EvaluateBoard(board);
            board.GenerateAllAlgebraicAvailableMoves();
            for (int i = 0; i < board.AlgebraicAvailableMoves.Count; i++)
            {
                Board hypotheticalBoard = Utilities.DeepClone<Board>(board);
                hypotheticalBoard.MakeMove(board.AlgebraicAvailableMoves[i]);
                int evaluation = Evaluation.EvaluateBoard(hypotheticalBoard);
                if (board.Turn == 1)
                {
                    if (evaluation >= bestMoveValue)
                    {
                        bestMove = board.AlgebraicAvailableMoves[i];
                        bestMoveValue = evaluation;
                    }
                }
                else if (board.Turn == -1)
                {
                    if (evaluation <= bestMoveValue)
                    {
                        bestMove = board.AlgebraicAvailableMoves[i];
                        bestMoveValue = evaluation;
                    }
                }
            }
            return bestMove;
        }

        public static string SearchPlyForBestMove(Board board, int depth, int maximizingPlayer)
        {
            string bestMove = "";
            int bestMoveValue = Evaluation.EvaluateBoard(board);
            int color = board.Turn;

            if(depth == 0)
            {

            }

            board.GenerateAllAlgebraicAvailableMoves();
            for (int i = 0; i < board.AlgebraicAvailableMoves.Count; i++)
            {
                Board hypotheticalBoard = Utilities.DeepClone<Board>(board);
                hypotheticalBoard.MakeMove(board.AlgebraicAvailableMoves[i]);
                int evaluation = Evaluation.EvaluateBoard(hypotheticalBoard);

            }





            return bestMove;
        }

    }
}
