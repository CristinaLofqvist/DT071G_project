using System;
namespace DT071G_project
{
    // Class that handels the rules
    public class Rules
    {
        // Show the rules
        public static void Show()
        {
            Console.WriteLine("Rules of the game:");
            Console.WriteLine("The game will present you a character that is present on your keyboard (a-z).");
            Console.WriteLine("Your job is to hit that character.");
            Console.WriteLine("This is done 10 times.");
            Console.WriteLine("Fastest times will be presented on the highscore list.");
            Console.WriteLine("GLHF hit return to go back to the menu.");
            // wait for user input return key must be pressed othewise loop until that
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
            Console.Clear();
        }
    }
}
