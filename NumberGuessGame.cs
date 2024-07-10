using System;
class NumberGuessGame
{
    static void Main(string[] args)
    {
        while (true)
        {
            int randno = Newnum(1, 11);
            Console.WriteLine(randno);
            int count = 1;

            while (count <= 3)
            {
                Console.Write("Enter a number between 1 and 10 (0 to quit): ");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input < 0 || input > 10)
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                    continue;
                }
                
                if (input == 0)
                    return;
                if (input < randno && count < 3)
                {
                    Console.WriteLine("Too Low, Try Again.");
                    ++count;
                    continue;
                }
                else if (input > randno && count < 3)
                {
                    Console.WriteLine("Too High, Try Again.");
                    ++count; 
                    continue;
                }
                else if(input == randno)
                {
                    Console.WriteLine(count < 3 ? "Congratulation! You guessed it in {0}{1} attempt.\n" : "Congratulation! You won the game.\n", count, count == 1 ? "st": "nd");
                    break;
                }
                else
                {
                   Console.WriteLine("Sorry you lost the Game! The number was "+ randno +".\n"); 
                   break;
                }
            }
        }
    }
    static int Newnum(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
}