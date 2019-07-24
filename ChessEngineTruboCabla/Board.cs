using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class Board
    {
        public int[] BitBoard = new int[120]; //The bit board representation of the board...my understanding is if the squares are occupied or not...chose int
        //insead of bool so I can do -1 for black, 0 for empty, and 1 for white...maybe different values like 1 for pawn, 3 for bishop...
        public int[] OutOfBoundsArea = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 29, 30, 39, 40, 49, 50, 59, 60, 69, 70, 79, 80, 89, 90, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119 };

        public Piece[] Pieces = new Piece[120];   //I think I will have an empty chess piece so I can do stuff with interfaces...or can empty piece be null object?
        public int PieceCntOnBoard  { get; set; }
        public string CurrentFEN { get; set; }
        public int Turn { get; set; } //1 for white, -1 for black, 0 for nobody...end of game, draw, win whatever
        public string CastleRights { get; set; }
        public int Halfmove { get; set; }
        public int FullMove { get; set; }
        public string enPassant {get; set;}
        public int checkStatus { get; set; } //-1 for black is in check. 0 for no one in check. 1 for white in check
        public int checkMateStatus { get; set; } //-1 for black checkmates white. 0 for no one in checkmate. 1 for white checkmates black
        public bool GameOver { get; set; }
        public Dictionary<int, int> MapTo64 = new Dictionary<int, int>();

        public Board()
        {
            CurrentFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            Turn = 1;
            CastleRights = "KQkq";
            Halfmove = 0;
            FullMove = 1;
            enPassant = "-";
            checkStatus = 0;
            checkMateStatus = 0;
            PieceCntOnBoard = 32;
            GameOver = false;
            #region initialize board
            //Initilaze a new Board...handles the initial positions of all the pieces
            //Handle the pawns
            for (int i = 30; i < 120; i++)
            {
                if (i > 30 && i < 39)
                {
                    Pieces[i] = new Pawn("black", i); //first parameter: black pawn, second parameter: position
                    BitBoard[i] = -1;
                }
                if (i > 80 && i < 89)
                {
                    Pieces[i] = new Pawn("white", i);
                    BitBoard[i] = 1;
                }
            }
            //Now handle the rest of the pieces individually
            //Rooks
            //black:
            Pieces[21] = new Rook("black", 21);
            Pieces[28] = new Rook("black", 28);
            BitBoard[21] = BitBoard[28] = -1;
            //white:
            Pieces[91] = new Rook("white", 91);
            Pieces[98] = new Rook("white", 98);
            BitBoard[91] = BitBoard[98] = 1;

            //Knights:
            //black:
            Pieces[22] = new Knight("black", 22);
            Pieces[27] = new Knight("black", 27);
            BitBoard[22] = BitBoard[27] = -1;
            //white:
            Pieces[92] = new Knight("white", 92);
            Pieces[97] = new Knight("white", 97);
            BitBoard[92] = BitBoard[97] = 1;

            //bishops
            //black
            Pieces[23] = new Bishop("black", 23);
            Pieces[26] = new Bishop("black", 26);
            BitBoard[23] = BitBoard[26] = -1;
            //white:
            Pieces[93] = new Bishop("white", 93);
            Pieces[96] = new Bishop("white", 96);
            BitBoard[93] = BitBoard[96] = 1;

            //Queens
            //black
            Pieces[24] = new Queen("black", 24);
            BitBoard[24] = -1;
            //white
            Pieces[94] = new Queen("white", 94);
            BitBoard[94] = 1;

            //King
            //black
            Pieces[25] = new King("black", 25);
            BitBoard[25] = -1;
            //white
            Pieces[95] = new King("white", 95);
            BitBoard[95] = 1;
            #endregion

            #region Initialize 120 mapping to 64
            //the following was created via SKYNET
            MapTo64.Add(21, 0);
            MapTo64.Add(22, 1);
            MapTo64.Add(23, 2);
            MapTo64.Add(24, 3);
            MapTo64.Add(25, 4);
            MapTo64.Add(26, 5);
            MapTo64.Add(27, 6);
            MapTo64.Add(28, 7);
            MapTo64.Add(31, 8);
            MapTo64.Add(32, 9);
            MapTo64.Add(33, 10);
            MapTo64.Add(34, 11);
            MapTo64.Add(35, 12);
            MapTo64.Add(36, 13);
            MapTo64.Add(37, 14);
            MapTo64.Add(38, 15);
            MapTo64.Add(41, 16);
            MapTo64.Add(42, 17);
            MapTo64.Add(43, 18);
            MapTo64.Add(44, 19);
            MapTo64.Add(45, 20);
            MapTo64.Add(46, 21);
            MapTo64.Add(47, 22);
            MapTo64.Add(48, 23);
            MapTo64.Add(51, 24);
            MapTo64.Add(52, 25);
            MapTo64.Add(53, 26);
            MapTo64.Add(54, 27);
            MapTo64.Add(55, 28);
            MapTo64.Add(56, 29);
            MapTo64.Add(57, 30);
            MapTo64.Add(58, 31);
            MapTo64.Add(61, 32);
            MapTo64.Add(62, 33);
            MapTo64.Add(63, 34);
            MapTo64.Add(64, 35);
            MapTo64.Add(65, 36);
            MapTo64.Add(66, 37);
            MapTo64.Add(67, 38);
            MapTo64.Add(68, 39);
            MapTo64.Add(71, 40);
            MapTo64.Add(72, 41);
            MapTo64.Add(73, 42);
            MapTo64.Add(74, 43);
            MapTo64.Add(75, 44);
            MapTo64.Add(76, 45);
            MapTo64.Add(77, 46);
            MapTo64.Add(78, 47);
            MapTo64.Add(81, 48);
            MapTo64.Add(82, 49);
            MapTo64.Add(83, 50);
            MapTo64.Add(84, 51);
            MapTo64.Add(85, 52);
            MapTo64.Add(86, 53);
            MapTo64.Add(87, 54);
            MapTo64.Add(88, 55);
            MapTo64.Add(91, 56);
            MapTo64.Add(92, 57);
            MapTo64.Add(93, 58);
            MapTo64.Add(94, 59);
            MapTo64.Add(95, 60);
            MapTo64.Add(96, 61);
            MapTo64.Add(97, 62);
            MapTo64.Add(98, 63);

            #endregion

        }

        public Board(string FEN)
        {
            if (FEN.Length > 0) //Make the board represent the FEN
            {

            }
        }

        public void SetGameFromFEN(string FEN)
        {
            CurrentFEN = FEN;
            string[] ValidCharacters = { "p", "r", "n", "b", "q", "k" };
            int[] EmptySquares = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int Square = 21;
            if (FEN.Length > 0)
            {
                Console.WriteLine(FEN.Substring(0, FEN.IndexOf(" ")).Length.ToString());
                for (int i = 0; i < FEN.Substring(0, FEN.IndexOf(" ")).Length; i++)
                {
                    if (ValidCharacters.Contains(FEN[i].ToString().ToLower()))
                    {
                        switch (FEN[i].ToString())
                        {
                            case "p":
                                Pieces[Square] = new Pawn("black", Square);
                                BitBoard[Square] = -1;
                                Square = Square + 1;
                                break;
                            case "P":
                                Pieces[Square] = new Pawn("white", Square);
                                BitBoard[Square] = 1;
                                Square = Square + 1;
                                break;
                            case "r":
                                Pieces[Square] = new Rook("black", Square);
                                BitBoard[Square] = -1;
                                Square = Square + 1;
                                break;
                            case "R":
                                Pieces[Square] = new Rook("white", Square);
                                BitBoard[Square] = 1;
                                Square = Square + 1;
                                break;
                            case "n":
                                Pieces[Square] = new Knight("black", Square);
                                BitBoard[Square] = -1;
                                Square = Square + 1;
                                break;
                            case "N":
                                Pieces[Square] = new Knight("white", Square);
                                BitBoard[Square] = 1;
                                Square = Square + 1;
                                break;
                            case "b":
                                Pieces[Square] = new Bishop("black", Square);
                                BitBoard[Square] = -1;
                                Square = Square + 1;
                                break;
                            case "B":
                                Pieces[Square] = new Bishop("white", Square);
                                BitBoard[Square] = 1;
                                Square = Square + 1;
                                break;
                            case "q":
                                Pieces[Square] = new Queen("black", Square);
                                BitBoard[Square] = -1;
                                Square = Square + 1;
                                break;
                            case "Q":
                                Pieces[Square] = new Queen("white", Square);
                                BitBoard[Square] = 1;
                                Square = Square + 1;
                                break;
                            case "k":
                                Pieces[Square] = new King("black", Square);
                                BitBoard[Square] = -1;
                                Square = Square + 1;
                                break;
                            case "K":
                                Pieces[Square] = new King("white", Square);
                                BitBoard[Square] = 1;
                                Square = Square + 1;
                                break;
                        }
                    }
                    //bool isNumber = Int32.TryParse(FEN[i].ToString(), out isNumber);
                    bool isNumber = Char.IsNumber(FEN[i]);
                    if(isNumber == true)
                    {
                        int spaces = (int) Char.GetNumericValue(FEN[i]);
                        for (int s = 0; s < spaces; s++)
                        {
                            Pieces[Square + s] = null;
                            BitBoard[Square + s] = 0;
                        }
                        Square = Square + spaces;
                        //i = i + spaces;
                        
                    }
                    //Is it end of rank?
                    if (FEN[i].ToString() == "/")
                    {
                        Square = Square + 2;
                    }
                }
            }
        }

        public void SetFenFromGame()
        {
            string newFEN = "";
            for (int i = 21; i < 99; i++)
            {

                if (Pieces[i] != null)
                {
                    if (Pieces[i].GetType() == typeof(Pawn))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            newFEN = newFEN + "p";
                        }
                        else
                        {
                            newFEN = newFEN + "P";
                        }
                    }
                    else if (Pieces[i].GetType() == typeof(Rook))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            newFEN = newFEN + "r";
                        }
                        else
                        {
                            newFEN = newFEN + "R";
                        }
                    }
                    else if (Pieces[i].GetType() == typeof(Knight))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            newFEN = newFEN + "n";
                        }
                        else
                        {
                            newFEN = newFEN + "N";
                        }
                    }
                    else if (Pieces[i].GetType() == typeof(Bishop))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            newFEN = newFEN + "b";
                        }
                        else
                        {
                            newFEN = newFEN + "B";
                        }
                    }
                    else if (Pieces[i].GetType() == typeof(Queen))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            newFEN = newFEN + "q";
                        }
                        else
                        {
                            newFEN = newFEN + "Q";
                        }
                    }
                    else if (Pieces[i].GetType() == typeof(King))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            newFEN = newFEN + "k";
                        }
                        else
                        {
                            newFEN = newFEN + "K";
                        }
                    }
                }
                else if(Pieces[i] == null)
                {
                    //see if last square has a number for the FEN has a number...that's one way to do it.
                    //another way is to count the next suares until the next forward slash and see how many of them are empty
                    int emptySquareCnt = 0;
                    while(Pieces[i] == null)
                    {
                        if (i % 10 == 8)
                        {
                            emptySquareCnt++;
                            break;
                        }                           
                        emptySquareCnt++;
                        i++;
                    }
                    newFEN = newFEN + emptySquareCnt.ToString();
                }

                if (i%10 == 8)
                {
                    if(i != 98)
                        newFEN = newFEN + "/";
                    i = i + 2;
                }
                    
            }
            string TurnString = "";
            if(Turn == 1)
            {
                TurnString = "w";
            }
            if(Turn == 2)
            {
                TurnString = "b";
            }
            newFEN = newFEN + " " + TurnString + " " + CastleRights + " " + enPassant + " " + Halfmove.ToString() + " " + FullMove.ToString();
            
            CurrentFEN = newFEN;
        }

        public bool MakeMove(string move)
        {
            bool validMoveMade = false;

            return validMoveMade;
        }
        

        public void PrintBoard()
        {
            for (int i = 20; i < 100; i++)
            {
                if (Pieces[i] != null)
                {
                    if (Pieces[i].GetType() == typeof(Pawn))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            Console.Write("p");
                        }
                        else
                        {
                            Console.Write("P");
                        }
                    }
                    else if (Pieces[i].GetType() == typeof(Rook))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            Console.Write("r");
                        }
                        else
                        {
                            Console.Write("R");
                        }
                    }
                    else if (Pieces[i].GetType() == typeof(Knight))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            Console.Write("n");
                        }
                        else
                        {
                            Console.Write("N");
                        }
                    }
                    else if (Pieces[i].GetType() == typeof(Bishop))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            Console.Write("b");
                        }
                        else
                        {
                            Console.Write("B");
                        }
                    }
                    else if (Pieces[i].GetType() == typeof(Queen))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            Console.Write("q");
                        }
                        else
                        {
                            Console.Write("Q");
                        }
                    }
                    else if (Pieces[i].GetType() == typeof(King))
                    {
                        if (Pieces[i].Color == "black")
                        {
                            Console.Write("k");
                        }
                        else
                        {
                            Console.Write("K");
                        }
                    }
                }
                else
                {
                    Console.Write("_");
                }

                if (i.ToString()[1].ToString() == "9") //i == 29 || i == 39 || i == 49 || i == 59 || i == 69 || i == 79 || i == 89 || i == 98
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}
