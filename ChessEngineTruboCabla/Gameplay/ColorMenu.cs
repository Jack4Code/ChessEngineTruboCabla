using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla.Gameplay
{
    public enum ColorChoice
    {
        White,
        Black
    }

    public static class ColorMenu
    {
        public static ColorChoice GetColor()
        {
            string selection = "";
            List<string> choices = new List<string>() { "1", "2", "3" };

            while (!choices.Contains(selection))
            {
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
            Console.WriteLine("  Player vs Computer");
            Console.WriteLine();
            Console.WriteLine("  Select Player Color");
            Console.WriteLine();
            Console.WriteLine("  1) White");
            Console.WriteLine("  2) Black");
            Console.WriteLine("  3) Random");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("  > ");
        }

        private static ColorChoice ProcessSelection(string selection)
        {
            switch (selection)
            {
                case "1": return ColorChoice.White;
                case "2": return ColorChoice.Black;
                default: return new Random().Next(2) == 0 ? ColorChoice.White : ColorChoice.Black;
            }
        }
    }
}
