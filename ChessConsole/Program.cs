using ChessEngineTruboCabla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            Board board = new Board();

            board.PrintBoard();
            //board.SetFEN("rn2kbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            board.SetFEN("rnbqkbn1/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            board.PrintBoard();



            Console.WriteLine("Press any key to escape: ");
            Console.ReadLine();
        }
    }
}
