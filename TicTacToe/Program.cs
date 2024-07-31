using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            int move;
            bool gameWon = false;

            while (!gameWon && !BoardIsFull())
            {
                DisplayBoard();
                Console.Write($"Player {currentPlayer}, enter your move (1-9): ");

                if (int.TryParse(Console.ReadLine(), out move) && move >= 1 && move <= 9 && board[move - 1] != 'X' && board[move - 1] != 'O')
                {
                    board[move - 1] = currentPlayer;
                    gameWon = CheckWin();

                    if (!gameWon)
                    {
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }

            DisplayBoard();

            Console.WriteLine(gameWon ? $"Player {currentPlayer} wins!" : "It's a draw!");
        }

        static void DisplayBoard()
        {
            Console.WriteLine($"     |     |      \n"+
                $"  {board[0]}  |  {board[1]}  |  {board[2]}  \n"+
                $"_____|_____|_____\n"+
                $"     |     |      \n"+
                $"  {board[3]}  |  {board[4]}  |  {board[5]}\n"+
                $"_____|_____|_____\n"+
                $"     |     |      \n"+
                $"  {board[6]}  |  {board[7]}  |  {board[8]}  \n"+
                $"     |     |      \n");
        }

        static bool CheckWin()
        {
            int[,] winningPositions = new int[,]
            {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
            };

            for (int i = 0; i < winningPositions.GetLength(0); i++)
            {
                if (board[winningPositions[i, 0]] == currentPlayer &&
                    board[winningPositions[i, 1]] == currentPlayer &&
                    board[winningPositions[i, 2]] == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }

        static bool BoardIsFull()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] != 'X' && board[i] != 'O')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
