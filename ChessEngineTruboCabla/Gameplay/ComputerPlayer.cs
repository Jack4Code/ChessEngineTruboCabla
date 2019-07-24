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

        public override string GetInput()
        {
            return "";
        }
    }
}
