using System;
using System.Collections.Generic;
using System.IO;

namespace DT071G_project
{
    // Class to handle highscores
    public class HighScores
    {
        // Method to retriev highscores from the file Highscores.txt
        private static List<string[]> GetHighScores()
        {
            string line;
            // Create a list of string arrays to represent what is in Highscores.txt
            List<string[]> returnList = new List<string[]>();
            try
            {
                // Open a stream to read from the file Highscores.txt
                StreamReader file = new StreamReader(@"Highscores.txt");
                // read line by line until end of file
                while ((line = file.ReadLine()) != null)
                {
                   /* 
                    * one line is name and score ex: crlo1900 5
                    * so split the read line on ' ' into a string array with 2 elements
                    * first element score[0] will contain the name and score[1] will contain the score
                    */
                    string[] score = line.Split(' ');
                    // Add this array to the list
                    returnList.Add(score);
                }
                // close the stream
                file.Close();
            }
            catch(Exception) 
            {
                //Do nothing just return an empty list
            }
           
            return returnList;
        }
        // Method to show the content of the file Highscore.txt which contain the highscores
        public static void Show()
        {
            Console.Clear();
            // Create a list of string arrays to represent what is in Highscores.txt
            List<string[]> highScores = GetHighScores();
            Console.WriteLine("HIGHSCORES!");
            // loop throu the lis and print the scores to the console
            foreach (string[] score in highScores)
            {
                string scoreToPrint = score[0] + " - " + score[1];
                Console.WriteLine(scoreToPrint);
            }
            Console.WriteLine("Hit return to go back to the menu.");
            // wait until user presses return button
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
            Console.Clear();
        }
        // memthod to set a new score in the Highscores.txt file
        private static bool SetNewScore(List<string[]> highScores)
        {
            try
            {
                // Open upp a stream for writing to the file Highscores.txt
                StreamWriter sw = new StreamWriter(@"Highscores.txt", false);
                // loop throu the list of string arrays 
                foreach (string[] score in highScores)
                {
                    // write the file line by line writing each elelemnt in the list
                    sw.WriteLine(score[0] + " " + score[1]);
                }
                // close the stream
                sw.Close();
                return true;
            }
            // if something goes wrong
            catch(Exception)
            {
                Console.WriteLine("Sorry but could not save your highscore.");
                Console.WriteLine("Hit return to go back to the menu.");
                // wait until user presses return button
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                }
                Console.Clear();
                return false;
            }
        }
        // method to set a new score if it is better than the current highscores
        public static void NewScore(int newScore)
        {
            // Get current highscores store them in a variable of type List<string[]> 
            List<string[]> highScores = GetHighScores();
            // loop through the current list of highscores
            for (int i = 0; i < highScores.Count; i++)
            {
                /*
                 * Get the score part of the element in the highscore list parse it to a int
                 * if the new score in the parameter newScore is lower "faster time better time"
                 * than the current highscore in the loop highScores[i][1] then it is a new highscore
                 */
                if (newScore < Int32.Parse(highScores[i][1]))
                {
                    Console.WriteLine("New highscore!");
                    Console.WriteLine("Please enter your name followed by return.");
                    // Get user input from terminal and store it in the variable string name
                    string name = Console.ReadLine();
                    // Remove any spaces in the input from the user
                    name = name.Replace(" ", string.Empty);
                    /* 
                     * Create a new string array with the values name and newScore.ToString() and set
                     * that element in the list as a new score
                     */
                    highScores[i] = new string[] { name, newScore.ToString() };
                    // Call method SetNewScore with the highscore list with the new score in as parameter
                    _ = SetNewScore(highScores);
                    return;
                }
            }
        }
    }
}
