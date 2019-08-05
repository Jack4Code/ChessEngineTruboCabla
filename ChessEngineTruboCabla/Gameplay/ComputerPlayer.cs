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
            board.GenerateAllAlgebraicAvailableMoves();
            List<string> moves = board.AlgebraicAvailableMoves;
            Random r = new Random();
            return moves[r.Next(0,moves.Count)];
        }
    }
}
