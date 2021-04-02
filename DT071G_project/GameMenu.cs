using System;

namespace DT071G_project
{
    // Class that handels the GameMenu
    public class GameMenu
    {
        // Field to represent a "state" if the menu has had an selection from a user
        private bool selectedState = false;
        // method to set the selectedState field
        private bool SetSelectedState(bool state)
        {
            selectedState = state;
            return selectedState;
        }
        //Return the value of the field selected State
        public bool Selected()
        {
            return selectedState;
        }
        // Set the selected state to false
        public void Unselect()
        {
            selectedState = false;
        }
        // Show the game menu
        public static void Show()
        {
            Console.WriteLine("Welcome to the reaction input game!");
            Console.WriteLine("Select one of the following by entering the number.");
            Console.WriteLine("1) See rules.");
            Console.WriteLine("2) Start game.");
            Console.WriteLine("3) See highscores.");
            Console.WriteLine("To exit this awesome game just input E.");
        }
        //Method to get a selection from a user input from the keyboard
        public int GetSelected()
        {
            // Read the pressed key from the keyboard
            switch (Console.ReadKey().Key)
            {
                // if 1 is pressed
                case ConsoleKey.D1:
                    Console.Clear();
                    return 1;
                // if 2 is pressed
                case ConsoleKey.D2:
                    Console.Clear();
                    _ = SetSelectedState(true);
                    return 2;
                // if 3 is pressed
                case ConsoleKey.D3:
                    return 3;
                // if e is pressed
                case ConsoleKey.E:
                    Console.Clear();
                    _ = SetSelectedState(true);
                    return 0;
                // if some thing else is pressed
                default:
                    Console.WriteLine("\nPlease enter an accepted input.");
                    // wait 1 second befor clearing the console
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    return -1;
            }
        }
    }
}