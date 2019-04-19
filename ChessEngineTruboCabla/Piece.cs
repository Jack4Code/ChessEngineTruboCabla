using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public interface Piece
    {
        int Position { get; set; }
        string Color { get; set; }

    }
}
