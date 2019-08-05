using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla.Gameplay
{
    public abstract class InputEnTitty
    {
        public string Name;

        public InputEnTitty(string name)
        {
            Name = name;
        }

        public abstract string GetInput(Board board);
    }
}
