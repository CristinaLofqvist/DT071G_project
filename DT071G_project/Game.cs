using System;
using System.Diagnostics;

namespace DT071G_project
{
// Game class that is the actual game
    public class Game
    {
        // Field that represent a "state" true if game should exit otherwise false
        private bool exitState = false;
        // Field that is the menu for the game of type GameMenu
        private readonly GameMenu gameMenu = new GameMenu();
        // method to set the field exitState 
        private bool SetExitState(bool state)
        {
            exitState = state;
            return exitState;
        }
        /*
         * Main method for the game, this method represent one game "round"
         */
        private static void GameMain()
        {
            // Random generator
            Random r = new Random();
            long totalTime = 0;
            // New stopwatch to keep track of time for the gameround
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Game will start in:");
            for (int i = 3; i > -1; i--)
            {
                if (i == 0)
                {
                    Console.WriteLine("GO!");

                }
                else
                {
                    Console.WriteLine(i);
                }
                // Just sleep to get a more accurate countdown to start aprox 3 seconds
                System.Threading.Thread.Sleep(1000);
            }
            // loop that loops 10 times, as one gameround is 10 rounds of this loop
            for (int counter = 0; counter < 11; counter++)
            {
                /* 
                 * A ConsoleKey is a class that represent a key that is on a regular keyboard
                 * In the line below the comment a new key is generated with help of the
                 * random generator r a number is generated between 65 and 91 wich
                 * reprsents a key between a-z then it is casted to a ConsoleKey type
                 * as r.next returns a int
                 */
                ConsoleKey consoleKey = (ConsoleKey)r.Next(65, 91);
                //clear console
                Console.Clear();
                /*
                 * just print which key to hit but have to use toString() on consoleKey
                 * to get the string reprsentation of it and as well make it a lowercase
                 */
                Console.WriteLine("Hit " + consoleKey.ToString().ToLowerInvariant());
                // start the stop watch to track the time to hit the given key
                stopwatch.Start();
                // loop as long as the Console.ReadKey.key (the key the user presses on the keyboard) is not the given key
                while (Console.ReadKey().Key != consoleKey)
                {
                    Console.Clear();
                    Console.WriteLine("Hit " + consoleKey.ToString().ToLowerInvariant());
                }
                // Stop the stop watch to get the time
                stopwatch.Stop();
                // add it to the total time
                totalTime += stopwatch.ElapsedMilliseconds;
                // reset the stopwatch
                stopwatch.Reset();
            }
            Console.Clear();
            // Total time is given in milliseconds so need to devide it with 1000 to get seconds
            Console.WriteLine("Your time was: " + (totalTime / 1000) + " seconds");
            // Store the new score if it is better than other scores
            HighScores.NewScore((int)totalTime / 1000);
            Console.WriteLine("Hit return to go back to the menu.");
            // Wait for return key to be pressed to get back to menu
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
            Console.Clear();
        }
        //Method to get the exit state field exitState
        public bool Exit()
        {
            return exitState;
        }
        //Method to run the game inkluding game menu
        public void Run()
        {
            // Check if the state selectedState is set to true in gameMenu if not show the game menu
            if (!gameMenu.Selected())
            {
                //Show the game menu
                GameMenu.Show();
                // variable to store the selection made by the user from the game menu
                int selected = gameMenu.GetSelected();
                // Switch case to act according to the user selection
                switch (selected)
                {
                    // Set exit state treu and exit the game
                    case 0:
                        _ = SetExitState(true);
                        break;
                    // Shoew the game rules
                    case 1:
                        Rules.Show();
                        break;
                    // Run one game
                    case 2:
                        GameMain();
                        gameMenu.Unselect();
                        break;
                    // Show the highscore list
                    case 3:
                        HighScores.Show();
                        break;
                }
            }
        }
    }
}