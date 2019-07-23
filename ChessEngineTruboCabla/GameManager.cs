using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class GameManager
    {
        public GameManager()
        {
            StartNewGame();
        }

        public GameManager(Board board)
        {
            PlayGame(board);
        }

        public void StartNewGame()
        {
            Board board = new Board();
            PlayGame(board);

        }

        public void PlayGame(Board board)
        {
            while (!board.GameOver)
            {
                if (board.Turn == 1)
                {
                    Console.WriteLine("Enter a move for white: ");
                    string move = Console.ReadLine();
                    bool legalMove = false;
                    while (!legalMove)
                    {
                        if (board.MakeMove(move))
                        {
                            legalMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                            Console.WriteLine("Please enter a valid move for white");
                        }   
                    } 
                }
                if (board.Turn == -1)
                {
                    Console.WriteLine("Enter a move for black: ");
                    string move = Console.ReadLine();
                    bool legalMove = false;
                    while (!legalMove)
                    {
                        if (board.MakeMove(move))
                        {
                            legalMove = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                            Console.WriteLine("Please enter a valid move for black");
                        }

                    }
                }
            }
            if (board.checkMateStatus == 1)
            {
                Console.WriteLine("White wins!");
            }
            else if (board.checkMateStatus == -1)
            {
                Console.WriteLine("Black wins!");
            }
            else
            {
                Console.WriteLine("Draw!");
            }
        }






    }
}
