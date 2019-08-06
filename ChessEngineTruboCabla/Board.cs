using ChessEngineTruboCabla.Gameplay;
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
        public int PieceCntOnBoard { get; set; }
        public string CurrentFEN { get; set; }
        public int Turn { get; set; } //1 for white, -1 for black, 0 for nobody...end of game, draw, win whatever
        public string CastleRights { get; set; }
        public int Halfmove { get; set; }
        public int FullMove { get; set; }
        public string enPassant { get; set; }
        public int checkStatus { get; set; } //-1 for black is in check. 0 for no one in check. 1 for white in check
        public int checkMateStatus { get; set; } //-1 for black checkmates white. 0 for no one in checkmate. 1 for white checkmates black
        public int PositionOfWhiteKing { get; set; }
        public int PositionOfBlackKing { get; set; }
        public bool GameOver { get; set; }
        public List<string> FENHistory { get; set; }
        public List<string> PGN { get; set; }
        public Dictionary<int, int> MapTo64 = new Dictionary<int, int>();
        public Dictionary<int, int> MapTo120 = new Dictionary<int, int>();
        public List<string> AlgebraicAvailableMoves { get; set; }

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
            PositionOfBlackKing = 25;
            PositionOfWhiteKing = 95;
            PieceCntOnBoard = 32;
            GameOver = false;
            PGN = new List<string>();
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

            #region Initialize 64 mapping to 120

            MapTo120.Add(0, 21);
            MapTo120.Add(1, 22);
            MapTo120.Add(2, 23);
            MapTo120.Add(3, 24);
            MapTo120.Add(4, 25);
            MapTo120.Add(5, 26);
            MapTo120.Add(6, 27);
            MapTo120.Add(7, 28);
            MapTo120.Add(8, 31);
            MapTo120.Add(9, 32);
            MapTo120.Add(10, 33);
            MapTo120.Add(11, 34);
            MapTo120.Add(12, 35);
            MapTo120.Add(13, 36);
            MapTo120.Add(14, 37);
            MapTo120.Add(15, 38);
            MapTo120.Add(16, 41);
            MapTo120.Add(17, 42);
            MapTo120.Add(18, 43);
            MapTo120.Add(19, 44);
            MapTo120.Add(20, 45);
            MapTo120.Add(21, 46);
            MapTo120.Add(22, 47);
            MapTo120.Add(23, 48);
            MapTo120.Add(24, 51);
            MapTo120.Add(25, 52);
            MapTo120.Add(26, 53);
            MapTo120.Add(27, 54);
            MapTo120.Add(28, 55);
            MapTo120.Add(29, 56);
            MapTo120.Add(30, 57);
            MapTo120.Add(31, 58);
            MapTo120.Add(32, 61);
            MapTo120.Add(33, 62);
            MapTo120.Add(34, 63);
            MapTo120.Add(35, 64);
            MapTo120.Add(36, 65);
            MapTo120.Add(37, 66);
            MapTo120.Add(38, 67);
            MapTo120.Add(39, 68);
            MapTo120.Add(40, 71);
            MapTo120.Add(41, 72);
            MapTo120.Add(42, 73);
            MapTo120.Add(43, 74);
            MapTo120.Add(44, 75);
            MapTo120.Add(45, 76);
            MapTo120.Add(46, 77);
            MapTo120.Add(47, 78);
            MapTo120.Add(48, 81);
            MapTo120.Add(49, 82);
            MapTo120.Add(50, 83);
            MapTo120.Add(51, 84);
            MapTo120.Add(52, 85);
            MapTo120.Add(53, 86);
            MapTo120.Add(54, 87);
            MapTo120.Add(55, 88);
            MapTo120.Add(56, 91);
            MapTo120.Add(57, 92);
            MapTo120.Add(58, 93);
            MapTo120.Add(59, 94);
            MapTo120.Add(60, 95);
            MapTo120.Add(61, 96);
            MapTo120.Add(62, 97);
            MapTo120.Add(63, 98);

            #endregion

        }

        public Board(string FEN)
        {
            FENHistory = new List<string>();
            if (FEN.Length > 0) //Make the board represent the FEN
            {
                SetGameFromFEN(FEN);
            }
        }

        public void SetGameFromFEN(string FEN)
        {
            CurrentFEN = FEN;
            FENHistory.Add(CurrentFEN);
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
                    if (isNumber == true)
                    {
                        int spaces = (int)Char.GetNumericValue(FEN[i]);
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

        public void SetGameFromPGN()
        {

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
                else if (Pieces[i] == null)
                {
                    //see if last square has a number for the FEN has a number...that's one way to do it.
                    //another way is to count the next suares until the next forward slash and see how many of them are empty
                    int emptySquareCnt = 0;
                    while (Pieces[i] == null)
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

                if (i % 10 == 8)
                {
                    if (i != 98)
                        newFEN = newFEN + "/";
                    i = i + 2;
                }

            }
            string TurnString = "";
            if (Turn == 1)
            {
                TurnString = "w";
            }
            if (Turn == 2)
            {
                TurnString = "b";
            }
            newFEN = newFEN + " " + TurnString + " " + CastleRights + " " + enPassant + " " + Halfmove.ToString() + " " + FullMove.ToString();

            CurrentFEN = newFEN;
        }

        public string[] AlgebraicSquareLocations = new string[]
            {
                "a8", "b8", "c8", "d8", "e8", "f8", "g8", "h8",
                "a7", "b7", "c7", "d7", "e7", "f7", "g7", "h7",
                "a6", "b6", "c6", "d6", "e6", "f6", "g6", "h6",
                "a5", "b5", "c5", "d5", "e5", "f5", "g5", "h5",
                "a4", "b4", "c4", "d4", "e4", "f4", "g4", "h4",
                "a3", "b3", "c3", "d3", "e3", "f3", "g3", "h3",
                "a2", "b2", "c2", "d2", "e2", "f2", "g2", "h2",
                "a1", "b1", "c1", "d1", "e1", "f1", "g1", "h1"
            };

        public static Dictionary<string, byte> AlgebraicToIntegerIndex = new Dictionary<string, byte>()
        {
            {"a8", 0}, {"a7", 8}, {"a6", 16}, {"a5", 24}, {"a4", 32}, {"a3", 40}, {"a2", 48}, {"a1", 56},
            {"b8", 1}, {"b7", 9}, {"b6", 17}, {"b5", 25}, {"b4", 33}, {"b3", 41}, {"b2", 49}, {"b1", 57},
            {"c8", 2}, {"c7", 10},{"c6", 18}, {"c5", 26}, {"c4", 34}, {"c3", 42}, {"c2", 50}, {"c1", 58},
            {"d8", 3}, {"d7", 11},{"d6", 19}, {"d5", 27}, {"d4", 35}, {"d3", 43}, {"d2", 51}, {"d1", 59},
            {"e8", 4}, {"e7", 12},{"e6", 20}, {"e5", 28}, {"e4", 36}, {"e3", 44}, {"e2", 52}, {"e1", 60},
            {"f8", 5}, {"f7", 13},{"f6", 21}, {"f5", 29}, {"f4", 37}, {"f3", 45}, {"f2", 53}, {"f1", 61},
            {"g8", 6}, {"g7", 14},{"g6", 22}, {"g5", 30}, {"g4", 38}, {"g3", 46}, {"g2", 54}, {"g1", 62},
            {"h8", 7}, {"h7", 15},{"h6", 23}, {"h5", 31}, {"h4", 39}, {"h3", 47}, {"h2", 55}, {"h1", 63},
        };

        public static Dictionary<int, string> IntegerIndexToAlgebraic = new Dictionary<int, string>()
        {
            {0, "a8"}, {8, "a7"}, {16, "a6"}, {24, "a5"}, {32, "a4"}, {40, "a3"}, {48, "a2"}, {56, "a1"},
            {1, "b8"}, {9, "b7"}, {17, "b6"}, {25, "b5"}, {33, "b4"}, {41, "b3"}, {49, "b2"}, {57, "b1"},
            {2, "c8"}, {10,"c7"}, {18, "c6"}, {26, "c5"}, {34, "c4"}, {42, "c3"}, {50, "c2"}, {58, "c1"},
            {3, "d8"}, {11,"d7"}, {19, "d6"}, {27, "d5"}, {35, "d4"}, {43, "d3"}, {51, "d2"}, {59, "d1"},
            {4, "e8"}, {12,"e7"}, {20, "e6"}, {28, "e5"}, {36, "e4"}, {44, "e3"}, {52, "e2"}, {60, "e1"},
            {5, "f8"}, {13,"f7"}, {21, "f6"}, {29, "f5"}, {37, "f4"}, {45, "f3"}, {53, "f2"}, {61, "f1"},
            {6, "g8"}, {14,"g7"}, {22, "g6"}, {30, "g5"}, {38, "g4"}, {46, "g3"}, {54, "g2"}, {62, "g1"},
            {7, "h8"}, {15,"h7"}, {23, "h6"}, {31, "h5"}, {39, "h4"}, {47, "h3"}, {55, "h2"}, {63, "h1"},
        };

        public MoveResult MakeMove(string move)
        {
            GenerateAllAlgebraicAvailableMoves();
            MoveResult result = MoveResult.Invalid;

            for (int i = 0; i < AlgebraicAvailableMoves.Count; i++)
            {
                if (AlgebraicAvailableMoves[i] == move)
                {
                    result = MoveResult.Valid;
                    if (move != "e1g1" && move != "e1c1" && move != "e8g8" && move != "e8c8")
                    {
                        //then we are dealing with a non-castling move
                        PGN.Add(move);
                        string firstSquare = move.Substring(0, 2);
                        string secondSquare = move.Substring(2, 2);
                        Piece pieceThatMoves = Pieces[MapTo120[AlgebraicToIntegerIndex[firstSquare]]];
                        int pieceThatMovesBit = BitBoard[MapTo120[AlgebraicToIntegerIndex[firstSquare]]];
                        Pieces[MapTo120[AlgebraicToIntegerIndex[firstSquare]]] = null;
                        BitBoard[MapTo120[AlgebraicToIntegerIndex[firstSquare]]] = 0;
                        Pieces[MapTo120[AlgebraicToIntegerIndex[secondSquare]]] = pieceThatMoves;
                        Pieces[MapTo120[AlgebraicToIntegerIndex[secondSquare]]].Position = MapTo120[AlgebraicToIntegerIndex[secondSquare]];
                        BitBoard[MapTo120[AlgebraicToIntegerIndex[secondSquare]]] = pieceThatMovesBit;
                        if (Pieces[MapTo120[AlgebraicToIntegerIndex[secondSquare]]].GetType() == typeof(King))
                        {
                            //update king position
                            if (Pieces[MapTo120[AlgebraicToIntegerIndex[secondSquare]]].Color == "white")
                            {
                                PositionOfWhiteKing = MapTo120[AlgebraicToIntegerIndex[secondSquare]];
                            }
                            else if (Pieces[MapTo120[AlgebraicToIntegerIndex[secondSquare]]].Color == "black")
                            {
                                PositionOfBlackKing = MapTo120[AlgebraicToIntegerIndex[secondSquare]];
                            }
                        }
                        Turn = Turn * -1;
                        DetermineIfCheck();
                        if (checkStatus != 0)
                        {
                            result = MoveResult.Check;
                        }
                    }
                    else
                    {
                        //dealing with castling move
                        PGN.Add(move);
                        //first handle the king
                        string firstSquare = move.Substring(0, 2);
                        string secondSquare = move.Substring(2, 2);
                        Piece pieceThatMoves = Pieces[MapTo120[AlgebraicToIntegerIndex[firstSquare]]];
                        int pieceThatMovesBit = BitBoard[MapTo120[AlgebraicToIntegerIndex[firstSquare]]];
                        Pieces[MapTo120[AlgebraicToIntegerIndex[firstSquare]]] = null;
                        BitBoard[MapTo120[AlgebraicToIntegerIndex[firstSquare]]] = 0;
                        Pieces[MapTo120[AlgebraicToIntegerIndex[secondSquare]]] = pieceThatMoves;
                        Pieces[MapTo120[AlgebraicToIntegerIndex[secondSquare]]].Position = MapTo120[AlgebraicToIntegerIndex[secondSquare]];
                        BitBoard[MapTo120[AlgebraicToIntegerIndex[secondSquare]]] = pieceThatMovesBit;
                        //then handle the respective rook
                        Turn = Turn * -1;
                    }
                }
            }


            return result;
        }

        public bool MakeMoves(string moves)
        {

            return true;
        }

        public void GenerateAllAlgebraicAvailableMoves() //this operates by player. it looks at the turn variable
        {
            string AllMoves = "";
            AlgebraicAvailableMoves = new List<String>();
            string PlayerColorToMove = Turn == 1 ? "white" : "black";
            for (int i = 21; i < 99; i++)
            {
                //if piece has available move...add it to AlgebraicAvailableMoves.Add("e2e4")
                if (Pieces[i] != null && Pieces[i].Color == PlayerColorToMove)
                {
                    Pieces[i].FindAllPossibleMoves(this);
                    //Pieces[i].PossibleMoves;
                    for (int m = 0; m < Pieces[i].PossibleMoves.Count; m++)
                    {
                        //Console.WriteLine("i: " + i.ToString());
                        //Console.WriteLine("m: " + m.ToString());
                        //Console.WriteLine(MapTo64[i].ToString());
                        //Console.WriteLine(MapTo64[Pieces[i].PossibleMoves[m]].ToString());
                        AllMoves += IntegerIndexToAlgebraic[MapTo64[i]] + IntegerIndexToAlgebraic[MapTo64[Pieces[i].PossibleMoves[m]]] + ",";
                        AlgebraicAvailableMoves.Add(IntegerIndexToAlgebraic[MapTo64[i]] + IntegerIndexToAlgebraic[MapTo64[Pieces[i].PossibleMoves[m]]]);
                    }
                }
            }
            AllMoves = AllMoves.TrimEnd(',');
            //Console.WriteLine(AllMoves);
        }

        public void DetermineIfCheck()
        {
            checkStatus = 0;
            //There are no legal moves for a side, and the side's king is in check
            if (Turn == 1)
            {
                //then we are dealing with white king
                //first check if there are pawns touching the king
                int[] PossiblePawns = new int[] { -11, -9 };
                for (int i = 0; i < PossiblePawns.Length; i++)
                {
                    //check for out of bounds?
                    if (!(OutOfBoundsArea.ToList().IndexOf(PositionOfWhiteKing + PossiblePawns[i]) != -1))
                    {
                        if (Pieces[PositionOfWhiteKing + PossiblePawns[i]] != null)
                        {
                            if (Pieces[PositionOfWhiteKing + PossiblePawns[i]].GetType() == typeof(Pawn) && Pieces[PositionOfWhiteKing + PossiblePawns[i]].Color == "black")
                            {
                                checkStatus = 1;
                                return;
                            }
                        }
                    }
                }
                int[] PossibleKnights = new int[] { -21, -19, -12, -8, 8, 12, 19, 21 };
                for (int i = 0; i < PossibleKnights.Length; i++)
                {
                    //check for out of bounds?
                    if (!(OutOfBoundsArea.ToList().IndexOf(PositionOfWhiteKing + PossibleKnights[i]) != -1))
                    {
                        if (Pieces[PositionOfWhiteKing + PossibleKnights[i]] != null)
                        {
                            if (Pieces[PositionOfWhiteKing + PossibleKnights[i]].GetType() == typeof(Knight) && Pieces[PositionOfWhiteKing + PossibleKnights[i]].Color == "black")
                            {
                                checkStatus = 1;
                                return;
                            }
                        }
                    }
                }
                int[] PossibleBishops = new int[] { -11, -9, 9, 11 };
                for (int i = 0; i < PossibleBishops.Length; i++)
                {
                    bool outOfBoundsOrBlocked = false;
                    int PositionOfSlider = PositionOfWhiteKing;
                    while (!outOfBoundsOrBlocked)
                    {
                        //check for out of bounds?
                        if (!(OutOfBoundsArea.ToList().IndexOf(PositionOfSlider + PossibleBishops[i]) != -1))
                        {
                            if (Pieces[PositionOfSlider + PossibleBishops[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleBishops[i]].GetType() == typeof(Bishop))
                                {
                                    if (Pieces[PositionOfSlider + PossibleBishops[i]].Color == "black")
                                    {
                                        checkStatus = 1;
                                        return;
                                    }
                                }
                            }

                            if (Pieces[PositionOfSlider + PossibleBishops[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleBishops[i]].Color == "white")
                                {
                                    //than it's white's own piece. we don't need to slide
                                    outOfBoundsOrBlocked = true;
                                }
                                else if (Pieces[PositionOfSlider + PossibleBishops[i]].Color == "black" && !(Pieces[PositionOfSlider + PossibleBishops[i]].GetType() == typeof(Bishop)))
                                {
                                    outOfBoundsOrBlocked = true;
                                }
                                else
                                {
                                    PositionOfSlider = PositionOfSlider + PossibleBishops[i];
                                }
                            }
                            else
                            {
                                PositionOfSlider = PositionOfSlider + PossibleBishops[i];
                            }
                        }
                        else
                        {
                            outOfBoundsOrBlocked = true;
                        }
                    }
                }
                int[] PossibleRooks = new int[] { -10, -1, 1, 10 };
                for (int i = 0; i < PossibleRooks.Length; i++)
                {
                    bool outOfBoundsOrBlocked = false;
                    int PositionOfSlider = PositionOfWhiteKing;
                    while (!outOfBoundsOrBlocked)
                    {
                        //check for out of bounds?
                        if (!(OutOfBoundsArea.ToList().IndexOf(PositionOfSlider + PossibleRooks[i]) != -1))
                        {
                            if (Pieces[PositionOfSlider + PossibleRooks[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleRooks[i]].GetType() == typeof(Rook))
                                {
                                    if (Pieces[PositionOfSlider + PossibleRooks[i]].Color == "black")
                                    {
                                        checkStatus = 1;
                                        return;
                                    }
                                }
                            }
                            if (Pieces[PositionOfSlider + PossibleRooks[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleRooks[i]].Color == "white")
                                {
                                    //than it's white's own piece. we don't need to slide
                                    outOfBoundsOrBlocked = true;
                                }
                                else if (Pieces[PositionOfSlider + PossibleRooks[i]].Color == "black" && !(Pieces[PositionOfSlider + PossibleRooks[i]].GetType() == typeof(Rook)))
                                {
                                    outOfBoundsOrBlocked = true;
                                }
                                else
                                {
                                    PositionOfSlider = PositionOfSlider + PossibleRooks[i];
                                }
                            }
                            else
                            {
                                PositionOfSlider = PositionOfSlider + PossibleRooks[i];
                            }
                        }
                        else
                        {
                            outOfBoundsOrBlocked = true;
                        }
                    }
                }
                int[] PossibleQueens = new int[] { -11, -10, -9, -1, 1, 9, 10, 11 };
                for (int i = 0; i < PossibleQueens.Length; i++)
                {
                    bool outOfBoundsOrBlocked = false;
                    int PositionOfSlider = PositionOfWhiteKing;
                    while (!outOfBoundsOrBlocked)
                    {
                        //check for out of bounds?
                        if (!(OutOfBoundsArea.ToList().IndexOf(PositionOfSlider + PossibleQueens[i]) != -1))
                        {
                            if (Pieces[PositionOfSlider + PossibleQueens[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleQueens[i]].GetType() == typeof(Queen))
                                {
                                    if (Pieces[PositionOfSlider + PossibleQueens[i]].Color == "black")
                                    {
                                        checkStatus = 1;
                                        return;
                                    }
                                }
                            }

                            if (Pieces[PositionOfSlider + PossibleQueens[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleQueens[i]].Color == "white")
                                {
                                    //than it's white's own piece. we don't need to slide
                                    outOfBoundsOrBlocked = true;
                                }
                                else if (Pieces[PositionOfSlider + PossibleQueens[i]].Color == "black" && !(Pieces[PositionOfSlider + PossibleQueens[i]].GetType() == typeof(Queen)))
                                {
                                    outOfBoundsOrBlocked = true;
                                }
                                else
                                {
                                    PositionOfSlider = PositionOfSlider + PossibleQueens[i];
                                }
                            }
                            else
                            {
                                PositionOfSlider = PositionOfSlider + PossibleQueens[i];
                            }
                        }
                        else
                        {
                            outOfBoundsOrBlocked = true;
                        }
                    }
                }
            }
            else if (Turn == -1)
            {
                //then we are dealing with black king
                //first check if there are pawns touching the king
                int[] PossiblePawns = new int[] { 11, 9 };
                for (int i = 0; i < PossiblePawns.Length; i++)
                {
                    //check for out of bounds?
                    if (!(OutOfBoundsArea.ToList().IndexOf(PositionOfBlackKing + PossiblePawns[i]) != -1))
                    {
                        if (Pieces[PositionOfBlackKing + PossiblePawns[i]] != null)
                        {
                            if (Pieces[PositionOfBlackKing + PossiblePawns[i]].GetType() == typeof(Pawn) && Pieces[PositionOfBlackKing + PossiblePawns[i]].Color == "white")
                            {
                                checkStatus = -1;
                                return;
                            }
                        }
                    }
                }
                int[] PossibleKnights = new int[] { -21, -19, -12, -8, 8, 12, 19, 21 };
                for (int i = 0; i < PossibleKnights.Length; i++)
                {
                    //check for out of bounds?
                    if (!(OutOfBoundsArea.ToList().IndexOf(PositionOfBlackKing + PossibleKnights[i]) != -1))
                    {
                        if (Pieces[PositionOfBlackKing + PossibleKnights[i]] != null)
                        {
                            if (Pieces[PositionOfBlackKing + PossibleKnights[i]].GetType() == typeof(Knight) && Pieces[PositionOfBlackKing + PossibleKnights[i]].Color == "white")
                            {
                                checkStatus = -1;
                                return;
                            }
                        }
                    }
                }
                int[] PossibleBishops = new int[] { -11, -9, 9, 11 };
                for (int i = 0; i < PossibleBishops.Length; i++)
                {
                    bool outOfBoundsOrBlocked = false;
                    int PositionOfSlider = PositionOfBlackKing;
                    while (!outOfBoundsOrBlocked)
                    {
                        //check for out of bounds?
                        if (!(OutOfBoundsArea.ToList().IndexOf(PositionOfSlider + PossibleBishops[i]) != -1))
                        {
                            if (Pieces[PositionOfSlider + PossibleBishops[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleBishops[i]].GetType() == typeof(Bishop))
                                {
                                    if (Pieces[PositionOfSlider + PossibleBishops[i]].Color == "white")
                                    {
                                        checkStatus = -1;
                                        return;
                                    }
                                }
                            }

                            if (Pieces[PositionOfSlider + PossibleBishops[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleBishops[i]].Color == "black")
                                {
                                    //than it's black's own piece. we don't need to slide
                                    outOfBoundsOrBlocked = true;
                                }
                                else if (Pieces[PositionOfSlider + PossibleBishops[i]].Color == "white" && !(Pieces[PositionOfSlider + PossibleBishops[i]].GetType() == typeof(Bishop)))
                                {
                                    outOfBoundsOrBlocked = true;
                                }
                                else
                                {
                                    PositionOfSlider = PositionOfSlider + PossibleBishops[i];
                                }
                            }
                            else
                            {
                                PositionOfSlider = PositionOfSlider + PossibleBishops[i];
                            }
                        }
                        else
                        {
                            outOfBoundsOrBlocked = true;
                        }
                    }
                }
                int[] PossibleRooks = new int[] { -10, -1, 1, 10 };
                for (int i = 0; i < PossibleRooks.Length; i++)
                {
                    bool outOfBoundsOrBlocked = false;
                    int PositionOfSlider = PositionOfBlackKing;
                    while (!outOfBoundsOrBlocked)
                    {
                        //check for out of bounds?
                        if (!(OutOfBoundsArea.ToList().IndexOf(PositionOfSlider + PossibleRooks[i]) != -1))
                        {
                            if (Pieces[PositionOfSlider + PossibleRooks[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleRooks[i]].GetType() == typeof(Rook))
                                {
                                    if (Pieces[PositionOfSlider + PossibleRooks[i]].Color == "white")
                                    {
                                        checkStatus = -1;
                                        return;
                                    }
                                }
                            }

                            if (Pieces[PositionOfSlider + PossibleRooks[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleRooks[i]].Color == "black")
                                {
                                    //than it's black's own piece. we don't need to slide
                                    outOfBoundsOrBlocked = true;
                                }
                                else if (Pieces[PositionOfSlider + PossibleRooks[i]].Color == "white" && !(Pieces[PositionOfSlider + PossibleRooks[i]].GetType() == typeof(Rook)))
                                {
                                    outOfBoundsOrBlocked = true;
                                }
                                else
                                {
                                    PositionOfSlider = PositionOfSlider + PossibleRooks[i];
                                }
                            }
                            else
                            {
                                PositionOfSlider = PositionOfSlider + PossibleRooks[i];
                            }
                        }
                        else
                        {
                            outOfBoundsOrBlocked = true;
                        }
                    }
                }
                int[] PossibleQueens = new int[] { -11, -10, -9, -1, 1, 9, 10, 11 };
                for (int i = 0; i < PossibleQueens.Length; i++)
                {
                    bool outOfBoundsOrBlocked = false;
                    int PositionOfSlider = PositionOfBlackKing;
                    while (!outOfBoundsOrBlocked)
                    {
                        //check for out of bounds?
                        if (!(OutOfBoundsArea.ToList().IndexOf(PositionOfSlider + PossibleQueens[i]) != -1))
                        {
                            if (Pieces[PositionOfSlider + PossibleQueens[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleQueens[i]].GetType() == typeof(Queen))
                                {
                                    if (Pieces[PositionOfSlider + PossibleQueens[i]].Color == "white")
                                    {
                                        checkStatus = -1;
                                        return;
                                    }
                                }
                            }

                            if (Pieces[PositionOfSlider + PossibleQueens[i]] != null)
                            {
                                if (Pieces[PositionOfSlider + PossibleQueens[i]].Color == "black")
                                {
                                    //than it's black's own piece. we don't need to slide
                                    outOfBoundsOrBlocked = true;
                                }
                                else if (Pieces[PositionOfSlider + PossibleQueens[i]].Color == "white" && !(Pieces[PositionOfSlider + PossibleQueens[i]].GetType() == typeof(Queen)))
                                {
                                    outOfBoundsOrBlocked = true;
                                }
                                else
                                {
                                    PositionOfSlider = PositionOfSlider + PossibleQueens[i];
                                }
                            }
                            else
                            {
                                PositionOfSlider = PositionOfSlider + PossibleQueens[i];
                            }
                        }
                        else
                        {
                            outOfBoundsOrBlocked = true;
                        }
                    }
                }
            }
        }

        public void DetermineIfCheckMate()
        {

        }

        public void DetermineIfStaleMate()
        {
            //There are no legal moves, but the king is not in check.
            //handle draw by repetition
        }

        public void PrintBoard()
        {
            //TODO: if player is black rotate the board

            ConsoleColorsToDefault();
            string files = "ABCDEFGH";
            for (int i = 10; i < 120; i++)
            {
                int modTen = i % 10;
                if (i < 20 || i > 99 && i < 110)
                {
                    if (modTen == 0)
                    {
                        Console.Write("   -");
                    }
                    else if (modTen == 9)
                    {
                        Console.WriteLine("-");
                    }
                    else
                    {
                        Console.Write("---");
                    }
                }
                else if (i >= 110)
                {
                    if (modTen > 0 && modTen < 9)
                    {
                        Console.Write(" " + files[modTen - 1] + " ");
                    }
                    else if (modTen == 0)
                    {
                        Console.Write("    ");
                    }
                    else if (modTen == 9)
                    {
                        Console.WriteLine();
                    }
                }
                else if (modTen > 0 && modTen < 9)
                {
                    PrintSquare(i, Pieces[i]);
                }
                else if (modTen == 0)
                {
                    Console.Write(9 - (i / 10 - 1) + " | ");
                }
                else if (modTen == 9)
                {
                    Console.WriteLine(" |");
                }
            }

            Console.WriteLine();
        }

        private void PrintSquare(int position, Piece piece)
        {
            Console.BackgroundColor = (position % 2) - (position / 10 % 2) == 0 ? ConsoleColor.DarkGray : ConsoleColor.Gray;
            Console.ForegroundColor = piece == null || piece.Color == "white" ? ConsoleColor.White : ConsoleColor.Black;
            Console.Write((piece == null ? "   " : " " + piece.DisplayChar + " "));

            ConsoleColorsToDefault();
        }

        private void ConsoleColorsToDefault()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
