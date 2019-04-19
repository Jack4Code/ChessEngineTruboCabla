using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class Queen : Piece
    {
        public int Position { get; set; }
        public string Color { get; set; }

        public Queen(string color, int position)
        {
            Position = position;
            Color = color;
        }
    }
}
