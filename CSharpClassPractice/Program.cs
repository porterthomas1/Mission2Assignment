using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CSharpClassPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Welcome user and initialize user input and number of dice rolls
            Console.WriteLine("Welcome to the dice throwing simulator!\n");
            string input;
            int rollCount;

            // Prompt user for number of dice rolls and convert input to integer datatype
            Console.Write("How many dice rolls would you like to simulate? ");
            input = Console.ReadLine();
            rollCount = Convert.ToInt32(input);

            // Create a Random function set to the variable "r" to generate a random number when called
            Random r = new Random();
            
            // Initialize the first array to a length of 11 (range 2 - 12 for possible dice combos)
            int[] rollArray = new int[11];

            // Iterate through the array and initialize each place to "0"
            for (int i = 0; i < 11; i++)
            {
                rollArray[i] = 0;
            }

            // Iterate through an arbitrary list of the rollCount range
            for (int i = 0; i < rollCount; i++)
            {
                // Generate 2 random numbers each from 1 to 6
                int diceOneRoll = r.Next(6);
                int diceTwoRoll = r.Next(6);

                // Increment the count of the instance of the given random number in the array
                rollArray[diceOneRoll + diceTwoRoll]++; 
            }

            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine("Total number of rolls = " + rollCount + ".\n");

            // For each value in the array, print the numbers from 2 - 12 (index numbers 0 - 11)
            for (int i = 0; i < 11; i++)
            {
                Console.Write((i + 2) + ": ");
                
                // Calculate percent as an integer for each roll combo count
                int percentCount = ((rollArray[i] * 100) / rollCount);
                
                // Display asterices for the percent count of each roll combo count
                for (int j = 0; j < percentCount; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            // Closing message
            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
    }
}
