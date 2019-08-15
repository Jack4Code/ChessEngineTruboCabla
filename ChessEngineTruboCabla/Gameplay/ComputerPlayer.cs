using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla.Gameplay
{
    public class ComputerPlayer : InputEnTitty
    {
        public ComputerPlayer(string name) : base(name)
        {

        }

        public override string GetInput(Board board)
        {
            //return "";
            string bestMove = "";
            int bestMoveValue = 0;
            board.GenerateAllAlgebraicAvailableMoves();
            for(int i=0; i<board.AlgebraicAvailableMoves.Count; i++)
            {
                Board hypotheticalBoard = Utilities.DeepClone<Board>(board);
                hypotheticalBoard.MakeMove(board.AlgebraicAvailableMoves[i]);
                int evaluation = Evaluation.EvaluateBoard(hypotheticalBoard);
                if (evaluation > bestMoveValue)
                {
                    bestMove = board.AlgebraicAvailableMoves[i];
                    bestMoveValue = evaluation;
                }
            }
            //List<string> moves = board.AlgebraicAvailableMoves;
            //Random r = new Random();
            //return moves[r.Next(0,moves.Count)];
            return bestMove;
        }
    }
}
