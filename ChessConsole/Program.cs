using ChessEngineTruboCabla;
using ChessEngineTruboCabla.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole
{
    public class Move
    {
        public Dictionary<string, int> moves { get; set; }

        //public Move(string moveToMake, int evaluation)
        //{
        //    move = 
        //}

        public List<Move> ResponseMoves { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //Testing Black
            //int square = 54;
            //Board board = new Board();
            //board.Pieces[square] = new Pawn("black", square);
            //board.Pieces[63] = new Pawn("white", 63);
            //board.BitBoard[63] = 1;
            //board.Pieces[65] = new Pawn("white", 65);
            //board.BitBoard[65] = 1;
            //board.Pieces[64] = new Pawn("black", 64);
            //board.BitBoard[64] = -1;


            //Testing White
            //int square = 81;
            //Board board = new Board();
            //board.Pieces[72] = new Pawn("black", 72);
            //board.BitBoard[72] = -1;

            //Board board = new Board();
            //int square = 54;
            //board.Pieces[square] = new Knight("white", square);
            //board.BitBoard[square] = 1;
            //board.PrintBoard();
            //board.GenerateAllAlgebraicAvailableMoves();
            //Console.WriteLine("The number of Available moves is: " + board.AlgebraicAvailableMoves.Count.ToString());
            //board.MakeMove("e2e4");
            //board.PrintBoard();
            //board.PrintBoard();
            ////board.MakeMove("e2e4");
            ////board.PrintBoard();
            //board.Pieces[square].FindAllPossibleMoves(board);
            //for(int i=0; i<board.Pieces[square].PossibleMoves.Count; i++)
            //{
            //    Console.WriteLine(board.Pieces[square].PossibleMoves[i]);
            //}

            //Board board = new Board("r1b1N2k/3p2Qp/8/p7/1p2P3/3P4/2PB3N/7K b - - 0 34");
            //board.PrintBoard();


            
            bool isQuit = false;

            while (!isQuit)
            {
                GameModeChoice gameMode = MainMenu.GetMode();
                if (gameMode == GameModeChoice.Quit)
                {
                    isQuit = true;
                }
                else
                {
                    string p1Name = "Player 1";
                    string p2Name = "Player 2";

                    Game game = SetupGame(gameMode, p1Name, p2Name);

                    if (game != null)
                    {
                        game.Start();
                    }
                }
            }

            Environment.Exit(0);
            




            /*
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
            */

            Console.WriteLine("Press any key to escape: ");
            Console.ReadLine();
        }

        public static Game SetupGame(GameModeChoice gameMode, string p1Name, string p2Name)
        {
            Game game = null;
            if (gameMode == GameModeChoice.PvP)
            {
                game = new Game(new HumanPlayer(p1Name), new HumanPlayer(p2Name));
            }
            else if (gameMode == GameModeChoice.PvC)
            {
                if (ColorMenu.GetColor() == ColorChoice.White)
                {
                    game = new Game(new HumanPlayer(p1Name), new ComputerPlayer(p2Name));
                }
                else
                {
                    game = new Game(new ComputerPlayer(p1Name), new HumanPlayer(p2Name));
                }
            }
            else if (gameMode == GameModeChoice.CvC)
            {
                game = new Game(new ComputerPlayer(p1Name), new ComputerPlayer(p2Name));
            }
            return game;
        }
    }
}


/*
 
    

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

            



    //SKYNET: CODE THAT WRITES ITSELF!!!
            int rowIncrement = 0;
            for (int i = 21; i < 99; i++)
            {
                if (i % 10 != 0 && i % 10 != 9)
                {
                    Console.WriteLine("MapTo120.Add(" + ((i - 21) - rowIncrement).ToString() + "," + i.ToString() + ");");
                }
                else if (i % 10 == 9)
                {
                    rowIncrement += 2;
                }
            }

*/
