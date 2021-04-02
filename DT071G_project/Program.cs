using System;

namespace DT071G_project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instacieat a new game
            Game game = new Game();
            do
            {
                // call run method in game
                game.Run();
            }
            // Do this as long as Exit returns false
            while (!game.Exit());
        }
    }
}
