using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // main program allows players to play as many times as they like
            bool playAnotherGame = true;

            while (playAnotherGame)
            {
                // each game is implemented in the Game class
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
