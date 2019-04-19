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

            Console.WriteLine("Press any key to escape: ");
            Console.ReadLine();
        }
    }
}
