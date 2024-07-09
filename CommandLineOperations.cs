using System;

class CommandLineOperations
{
    static void Main(string[] args)
    {

        int[] numbers = new int[5];

        for (int i = 0; i < 5; i++)
        {
            if (!int.TryParse(args[i], out numbers[i]))
            {
                Console.WriteLine("Invalid argument provided: {args[i]}");
                return;
            }
        }

        int max = numbers[0];
        int min = numbers[0];
        int sum = 0;

        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }

            if (num < min)
            {
                min = num;
            }

            sum += num;
        }

        double average = (double)sum / 5;

        Console.WriteLine("Maximum number is: "+max);
        Console.WriteLine("Minimum number is: "+min);
        Console.WriteLine("Sum of numbers is: "+sum);
        Console.WriteLine("Average of numbers is: "+average);
    }
}
