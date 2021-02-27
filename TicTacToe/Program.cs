using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAnotherGame = true;

            while (playAnotherGame)
            {
                new Game();
                Console.WriteLine("Press 'e' to exit. Enter anything else to play again.");
                string continueGame = Console.ReadLine();
                if(continueGame.ToLower() == "e") { playAnotherGame = false; }
            }

            Console.WriteLine("\nEnd of Program. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
