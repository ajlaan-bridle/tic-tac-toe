using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        // this class handles running a game, taking turns, and determining the winner
        private static readonly string X = "X";
        private static readonly string O = "O";
        private bool gameOver;
        private readonly bool playerXTurn;
        private string winner;
        private readonly int input;
        
        public Game()
        {
            gameOver = false;
            playerXTurn = true;
            winner = String.Empty;

            Grid grid = new Grid();
            
            while (!gameOver)
            {
                input = 0;
                grid.PrintGrid();

                if (playerXTurn)
                {
                    Console.WriteLine("It is Player X's turn. Enter an available grid number to place your 'X'.");
                    int.TryParse(Console.ReadLine(), out input);
                }
                else
                {
                    Console.WriteLine("It is Player O's turn. Enter an available grid number to place your 'O'.");
                    int.TryParse(Console.ReadLine(), out input);
                }

                if(IsEntryValid(grid, input))
                {
                    MarkGrid(grid, input);
                    CheckWinner(grid);
                    if (IsGridFull(grid)) { gameOver = true; }
                    playerXTurn = !playerXTurn;
                }
            }

            grid.PrintGrid();
            if(winner == X || winner == O)
            {
                Console.WriteLine("The game is over, and the winner is {0}.\n", winner);
            }
            else { Console.WriteLine("The game is a draw.\n"); }
            
        }

        private void CheckWinner(Grid grid)
        {
            string diag1Mark = String.Empty;
            string diag2Mark = String.Empty;
            int len = grid.GridMarks.GetLength(0);
            for (int i = 0; i < len; i++)
            {
                string rowMark = String.Empty;
                string colMark = String.Empty;
                // check row/column
                for (int j = 0; j < len; j++)
                {
                    // row check
                    if (grid.GridMarks[i, j] == X && rowMark == String.Empty)
                    {
                        rowMark = X;
                    }
                    else if (grid.GridMarks[i, j] == O && rowMark == String.Empty)
                    {
                        rowMark = O;
                    }
                    else if (grid.GridMarks[i, j] != rowMark)
                    {
                        rowMark = "None";
                    }

                    // column check
                    if (grid.GridMarks[j, i] == X && colMark == String.Empty)
                    {
                        colMark = X;
                    }
                    else if (grid.GridMarks[j, i] == O && colMark == String.Empty)
                    {
                        colMark = O;
                    }
                    else if (grid.GridMarks[j, i] != colMark)
                    {
                        colMark = "None";
                    }
                }

                if(rowMark == X || rowMark == O)
                {
                    winner = rowMark;
                    gameOver = true;
                    return;
                }

                if(colMark == X || colMark == O)
                {
                    winner = colMark;
                    gameOver = true;
                    return;
                }

                // check diagonals
                if (grid.GridMarks[i, i] == X && diag1Mark == String.Empty)
                {
                    diag1Mark = X;
                }
                else if (grid.GridMarks[i, i] == O && diag1Mark == String.Empty)
                {
                    diag1Mark = O;
                }
                else if (grid.GridMarks[i, i] != diag1Mark)
                {
                    diag1Mark = "None";
                }

                if (grid.GridMarks[i, len - 1 - i] == X && diag2Mark == String.Empty)
                {
                    diag2Mark = X;
                }
                else if (grid.GridMarks[i, len - 1 - i] == O && diag2Mark == String.Empty)
                {
                    diag2Mark = O;
                }
                else if (grid.GridMarks[i, len - 1 - i] != diag2Mark)
                {
                    diag2Mark = "None";
                }
            }

            if (diag1Mark == X || diag1Mark == O)
            {
                winner = diag1Mark;
                gameOver = true;
                return;
            }

            if (diag2Mark == X || diag2Mark == O)
            {
                winner = diag2Mark;
                gameOver = true;
                return;
            }

            return;
        }

        private bool IsEntryValid(Grid grid, int input)
        {
            if (input < 1 || input > 9)
            {
                Console.WriteLine("The grid number provided is invalid. Provide a number for an available grid space.");
                Console.ReadKey();
                return false;
            }

            int row = GetRow(grid, input);
            int col = GetCol(grid, input);

            if (grid.GridMarks[row, col] == X || grid.GridMarks[row, col] == O)
            {
                Console.WriteLine("This grid space has already been taken. Provide a number for an available grid space.");
                Console.ReadKey();
                return false;
            }

            return true;
        }

        private void MarkGrid(Grid grid, int input)
        {
            int row = GetRow(grid, input);
            int col = GetCol(grid, input);

            grid.GridMarks[row, col] = playerXTurn ? X : O;
            return;
        }

        private int GetRow(Grid grid, int input)
        {
            return (input - 1) / grid.GridMarks.GetLength(0);
        }

        private int GetCol(Grid grid, int input)
        {
            return (input - 1) % grid.GridMarks.GetLength(0);
        }

        private bool IsGridFull(Grid grid)
        {
            int len = grid.GridMarks.GetLength(0);

            for (int i = 0; i < len; i++)
            {
                for(int j = 0; j < len; j++)
                {
                    if(grid.GridMarks[i, j] != X && grid.GridMarks[i, j] != O) { return false; }
                }
            }

            return true;
        }
    }
}
