﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    [Serializable]
    public class Queen : Piece
    {
        //public int Position { get; set; }
        //public string Color { get; set; }
        //public List<int> PossibleMoves { get; set; }

        //public override int[] HowPieceMoves => throw new NotImplementedException();
        public override int[] HowPieceMoves { get { return new int[] { -11, -10, -9, -1, 1, 9, 10, 11 }; } }

        public Queen(string color, int position)
        {
            Position = position;
            Color = color;
            DisplayChar = Color == "white" ? "Q" : "q";
            Value = 900;

            SquareTable = new int[64]
            {
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0,  0,  0,  0,  0,  0,  0,
                0, 20, 20, 20, 20, 20, 20,  0,
                0, 20, 20, 20, 20, 20, 20,  0,
                0, 20, 20, 20, 20, 20, 20,  0,
                0, 20, 20, 20, 20, 20, 20,  0,
                0,  0,  0,  0,  0,  0,  0,  0,
                0,  0,  0,  0,  0,  0,  0,  0
            };
        }

        public override void FindAllPossibleMoves(Board board)
        {
            PossibleMoves = new List<int>();
            for (int i = 0; i < HowPieceMoves.Length; i++)
            {
                RecursiveMovesGet(board, Position, HowPieceMoves[i]);
            }
        }

        public void RecursiveMovesGet(Board board, int position, int direction)
        {
            int pieceColor = 0;
            if (Color == "white")
            {
                pieceColor = 1;
            }
            else
            {
                pieceColor = -1;
            }
            //first handle out of bounds
            if (!(board.OutOfBoundsArea.ToList().IndexOf(position + direction * pieceColor * -1) != -1))
            {
                //now that we know not out of bounds let's try each way the piece moves over and over until we are either out of bounds or blocked or a capture is possible
                //Are we blocked?
                if (board.Pieces[position + direction * pieceColor * -1] == null)
                {
                    //okay we're not blocked
                    PossibleMoves.Add((direction * pieceColor * -1) + position);
                    RecursiveMovesGet(board, -1 * pieceColor * (direction) + position, (direction));
                }
                else if (board.Pieces[position + direction * pieceColor * -1] != null)
                {
                    //okay we're blocked, but is the block an enemy piece?
                    if (board.Pieces[position + direction * pieceColor * -1].Color != Color && board.Pieces[position + direction * pieceColor * -1].Color != null)
                    {
                        PossibleMoves.Add((direction * pieceColor * -1) + position);
                    }
                    return;
                }
            }
            else
            {
                return;
            }

            //return new List<int>();
        }
    }
}
