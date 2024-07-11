using System;
class NumberGuessGame
{
    static void Main(string[] args)
    {
        while (true)
        {
            int randomNumber = NewNum(1, 11);
            int counter = 1;

            while (counter <= 3)
            {
                Console.Write("Enter a number between 1 and 10 (0 to quit): ");
                int inputNumber = Convert.ToInt32(Console.ReadLine());

                if (inputNumber < 0 || inputNumber > 10)
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                    continue;
                }
                
                if (inputNumber == 0)
                    return;
                if (inputNumber < randomNumber && counter < 3)
                {
                    Console.WriteLine("Too Low, Try Again.");
                    ++counter;
                    continue;
                }
                else if (inputNumber > randomNumber && counter < 3)
                {
                    Console.WriteLine("Too High, Try Again.");
                    ++counter; 
                    continue;
                }
                else if(inputNumber == randomNumber)
                {
                    Console.WriteLine(counter < 3 ? "Congratulation! You guessed it in {0}{1} attempt.\n" : "Congratulation! You won the game.\n", counter, counter == 1 ? "st": "nd");
                    break;
                }
                else
                {
                   Console.WriteLine("Sorry you lost the Game! The number was "+ randomNumber +".\n"); 
                   break;
                }
            }
        }
    }
    static int NewNum(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
}