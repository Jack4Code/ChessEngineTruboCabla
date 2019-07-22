using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla
{
    public class Pawn : Piece
    {
        //Class Specific Variables
        public int MultipleSquareMoves = 1; //7; for queen

        //Constructors
        public Pawn() { }

        public Pawn(string color, int position)
        {
            Position = position;
            Color = color;

        }

        public override void FindAllPossibleMoves(Board board)
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


            PossibleMoves = new List<int>();
            if (Position.ToString().Substring(0, 1) == "8" || Position.ToString().Substring(0, 1) == "3")
            {

                for (int i = 0; i < HowPieceMoves.Length; i++)
                {
                    if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1] == null && !(board.OutOfBoundsArea.ToList().IndexOf(Position + HowPieceMoves[i] * pieceColor * -1) != -1))
                    {
                        PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                    }
                }
            }
            else
            {
                for (int i = 0; i < HowPieceMoves.Length - 1; i++)
                {
                    if (board.Pieces[Position + HowPieceMoves[i] * pieceColor * -1] == null && !(board.OutOfBoundsArea.ToList().IndexOf(Position + HowPieceMoves[i] * pieceColor * -1) != -1))
                    {
                        PossibleMoves.Add((HowPieceMoves[i] * pieceColor * -1) + Position);
                    }
                }
            }
        }

        public override int[] HowPieceMoves { get { return new int[] { 9, 10, 11, 20 }; } }

    }
}
