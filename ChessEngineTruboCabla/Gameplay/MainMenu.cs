using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla.Gameplay
{
    public enum GameModeChoice
    {
        PvP,
        PvC,
        CvC,
        Quit
    }

    public static class MainMenu
    {

        public static GameModeChoice GetMode()
        {
            string selection = "";
            List<string> choices = new List<string>() { "1", "2", "3", "4" };

            while (!choices.Contains(selection)) {
                DrawMenu();
                selection = Console.ReadKey().KeyChar.ToString();
            }

            return ProcessSelection(selection);
        }

        private static void DrawMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("  ************************");
            Console.WriteLine("  **  TruboCabla Chess  **");
            Console.WriteLine("  ************************");
            Console.WriteLine();
            Console.WriteLine("  1) Player vs Player");
            Console.WriteLine("  2) Player vs Computer");
            Console.WriteLine("  3) Computer vs Computer");
            Console.WriteLine();
            Console.WriteLine("  4) Exit");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("  > ");
        }

        private static GameModeChoice ProcessSelection(string selection)
        {
            switch (selection)
            {
                case "1": return GameModeChoice.PvP;
                case "2": return GameModeChoice.PvC;
                case "3": return GameModeChoice.CvC;
                default: return GameModeChoice.Quit;
            }
        }
    }
}
