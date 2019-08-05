using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla.Gameplay
{
    public class HumanPlayer : InputEnTitty
    {
        public HumanPlayer(string name) : base(name)
        {

        }

        public override string GetInput(Board board)
        {
            return Console.ReadLine();
        }
    }
}
