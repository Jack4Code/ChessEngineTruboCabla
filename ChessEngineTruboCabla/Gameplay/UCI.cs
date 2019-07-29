using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla.Gameplay
{
    public class UCI
    {
        public static void uciCommunicator()
        {
            TextReader input = Console.In;
            string inputStr = input.ReadLine();
            if (inputStr == "uci")
            {
                inputUCI();
            }
            else if (inputStr == "isready")
            {
                Console.WriteLine("readyok");
            }
            else if (inputStr == "ucinewgame")
            {
                inputNewGame();
            }
            else if (inputStr.StartsWith("position"))
            {
                inputPosition(inputStr);
            }

        }
        public static void inputUCI()
        {
            Console.WriteLine("id name TruboCabla");
            Console.WriteLine("id author Jack Giannini");
            Console.WriteLine("uciok");
        }

        public static void inputNewGame()
        {
            //setup a new game
        }

        public static void inputPosition(string input)
        {
            //remove first 9 characters of string
            input = input.Substring(9);
            if (input.Contains("startpos"))
            {
                Board board = new Board("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            }
            else if (input.Contains("fen"))
            {
                Board board = new Board(input.Substring(4));
            }
            if (input.Contains("moves"))
            {
                input = input.Substring(6);
            }
        }
    }
}
