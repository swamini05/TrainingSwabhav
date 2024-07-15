using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceApp
{
    internal class Program
    {
        static Random random = new Random();
        static int totalScore = 0;
        static int turns = 0;
        static bool gameOver = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game of Pig!");

            while (!gameOver)
            {
                turns++;
                Console.WriteLine($"\nTURN {turns}:");
                Turn();
            }
            Console.WriteLine("Game over!");
        }

        static void Turn()
        {
            int turnScore = 0;
            bool turnOver = false;

            while (!turnOver)
            {
                Console.WriteLine("\nEnter 'r' to roll again, 'h' to hold.");
                char choice = Convert.ToChar(Console.ReadLine());

                if (choice == 'r')
                {
                    turnOver = Roll(ref turnScore);
                }
                else if (choice == 'h')
                {
                    turnOver = true;
                    Console.WriteLine($"Your turn score is {turnScore} and your total score is {totalScore}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'r' to roll again or 'h' to hold.");
                }
            }
        }

        static bool Roll(ref int turnScore)
        {
            int roll = random.Next(1, 7);
            Console.WriteLine($"You rolled: {roll}");

            if (roll == 1)
            {
                Console.WriteLine("Turn over. No Score");
                totalScore -= turnScore;
                turnScore = 0;
                return true;
            }
            else
            {
                turnScore += roll;
                totalScore += roll;
                Console.WriteLine($"Your turn score is {turnScore} and your total score is {totalScore}");

                if (totalScore >= 20)
                {
                    Console.WriteLine($"You Win! You finished in {turns} turns!");
                    gameOver = true;
                    return true;
                }

                return false;
            }
        }
    }
}

