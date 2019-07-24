using ChessEngineTruboCabla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Board board = new Board();
            //board.Pieces[24] = null;
            //board.BitBoard[24] = 0;
            board.Pieces[85] = null;
            board.BitBoard[85] = 0;
            board.Pieces[65] = new Pawn("white", 65);
            board.BitBoard[65] = 1;

            board.Pieces[35] = null;
            board.BitBoard[35] = 0;
            board.Pieces[55] = new Pawn("black", 55);
            board.BitBoard[55] = -1;
            board.SetGameFromFEN("r5k1/p5p1/2nbp3/3p3Q/3P4/1Pq1P1P1/P1P5/5K2 w - - 2 26");
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

            //board.Pieces[31].FindAllPossibleMoves(board);
            //for(int i=0; i<board.Pieces[31].PossibleMoves.Count; i++)
            //{
            //    Console.WriteLine(board.Pieces[31].PossibleMoves[i]);
            //}

            Console.WriteLine(Evaluation.EvaluateBoard(board));

            


            Console.WriteLine("Press any key to escape: ");
            Console.ReadLine();
        }
    }
}


/*
 
    Dictionary<int, int> MapTo64 = new Dictionary<int, int>();
            MapTo64.Add(21, 0);
            MapTo64.Add(22, 1);

            //SKYNET: CODE THAT WRITES ITSELF!!!
            int rowIncrement = 0;
            for (int i=21; i<99; i++)
            {
                if(i%10 != 0 && i%10 != 9)
                {
                    Console.WriteLine("MapTo64.Add(" + i.ToString() + ", " + ((i - 21)-rowIncrement).ToString() + ");");
                }
                else if(i%10 == 9)
                {
                    rowIncrement += 2;
                }
            }

            Console.WriteLine(MapTo64[22]);

*/
