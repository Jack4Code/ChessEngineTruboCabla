using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTruboCabla.Gameplay
{
    public class Game
    {
        private InputEnTitty playerWhite;
        private InputEnTitty playerBlack;

        private InputEnTitty activePlayer;

        private string currentCommand;
        private string gameMessage;

        private bool isQuit;
        private bool isGameOver;

        private Board board;

        public Game(InputEnTitty pWhite, InputEnTitty pBlack)
        {
            playerWhite = pWhite;
            playerBlack = pBlack;

            activePlayer = playerWhite;

            currentCommand = "";
            gameMessage = "";

            isQuit = false;
            isGameOver = false;

            board = new Board();
        }

        public void Start()
        {
            Render();

            while (!isQuit)
            {
                ProcessInput(board);
                Update();
                Render();
            }
        }

        public void PrintBoardEvaluation()
        {
            Console.WriteLine();
            Console.WriteLine("  Game Evaluation: " + Evaluation.EvaluateBoard(board));
            Console.WriteLine();
        }

        public void PrintGameMessage()
        {
            Console.WriteLine();
            Console.WriteLine("  " + gameMessage);
            Console.WriteLine();
        }

        public void PrintPlayerPrompt()
        {
            if (!isGameOver)
            {
                Console.WriteLine("  " + activePlayer.Name + "'s Turn");
            }
            else
            {
                Console.WriteLine("  Press Any Key to Exit");
            }
            Console.Write("  > ");
        }

        private void ProcessInput(Board board)
        {
            if (!isGameOver)
            {
                currentCommand = activePlayer.GetInput(board);
            }
            else
            {
                Console.ReadKey();
                currentCommand = "quit";
            }
        }

        private void Update()
        {
            if (currentCommand == "quit")
            {
                isQuit = true;
            }
            else if (currentCommand == "concede")
            {
                isGameOver = true;
                gameMessage = "Game Over: " + (activePlayer == playerWhite ? playerBlack.Name : playerWhite.Name) + " Wins!";
            }
            else
            {
                switch (board.MakeMove(currentCommand))
                {
                    case MoveResult.Check:
                        gameMessage = "Last Move: " + currentCommand + " CHECK!";
                        activePlayer = activePlayer == playerWhite ? playerBlack : playerWhite;
                        break;
                    case MoveResult.Valid:
                        gameMessage = "Last Move: " + currentCommand;
                        activePlayer = activePlayer == playerWhite ? playerBlack : playerWhite;
                        break;
                    case MoveResult.Invalid:
                        gameMessage = "Invalid Move";
                        break;
                    case MoveResult.Checkmate:
                        isGameOver = true;
                        gameMessage = "Game Over: " + activePlayer.Name + " Wins!";
                        break;
                    case MoveResult.Stalemate:
                        isGameOver = true;
                        gameMessage = "Game Over: Stalemate";
                        break;

                }
            }
        }

        private void Render()
        {
            Console.Clear();

            PrintBoardEvaluation();
            board.PrintBoard();
            PrintGameMessage();
            PrintPlayerPrompt();
        }
    }
}
