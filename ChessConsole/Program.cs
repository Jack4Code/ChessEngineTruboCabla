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
            //board.SetGameFromFEN("rnbqkbn1/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            //Console.WriteLine(board.CurrentFEN);
            //board.Pieces[25] = null;
            //board.Pieces[26] = null;
            //board.Pieces[27] = null;
            //board.SetFenFromGame();
            //board.PrintBoard();
            //Console.WriteLine(board.CurrentFEN);

            board.Pieces[31].FindAllPossibleMoves(board);
            for(int i=0; i<board.Pieces[31].PossibleMoves.Count; i++)
            {
                Console.WriteLine(board.Pieces[31].PossibleMoves[i]);
            }
            

            Console.WriteLine("Press any key to escape: ");
            Console.ReadLine();
        }
    }
}
