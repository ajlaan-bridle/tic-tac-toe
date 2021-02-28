using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Grid
    {
        // this class represents the grid that is printed to the console
        public string[,] GridMarks { get; set; }

        public Grid()
        {
            // represent the grid as a 3x3 array of ints
            GridMarks = new string[,] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

        }

        public void PrintGrid()
        {
            // clears the console screen and prints the current state of the grid
            string gaps = "          |     |    ";
            string numbers = "       {0}  |  {1}  |  {2} ";
            string underLine = "     _____|_____|_____";

            string[] lines =
            {
                gaps,
                String.Format(numbers,GridMarks[0,0],GridMarks[0,1],GridMarks[0,2]),
                underLine,
                gaps,
                String.Format(numbers,GridMarks[1,0],GridMarks[1,1],GridMarks[1,2]),
                underLine,
                gaps,
                String.Format(numbers,GridMarks[2,0],GridMarks[2,1],GridMarks[2,2]),
                gaps
            };

            Console.Clear();
            Console.WriteLine("\n");
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\n\n");
        }
    }
}
