using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InOutParamsDemo
{
    internal class InOutParams
    {
        static void Main(string[] args)
        {
            int myNumber = 5;
            Console.WriteLine("Factorial of {0} is: {1}", myNumber, Factorial(in myNumber));

            Console.WriteLine("Average of numbers 7, 14, 21, 28, 35, 42 is: {0}", CalculateAverage(7, 14, 21, 28, 35, 42));

            FindMaxValue(out int max, 10, 20, 30, 40, 50);
            Console.WriteLine("Max value using out parameter: {0}", max);
        }
        public static int Factorial(in int inputNumber1)
        {
            int result = 1;
            for (int i = 1; i <= inputNumber1; i++)
            {
                result *= i;
            }
            return result;
        }

        public static double CalculateAverage(params int[] numbers)
        {
            int sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }
            return (double)sum / numbers.Length;
        }

        public static void FindMaxValue(out int max, params int[] numbers)
        {
            max = numbers[0];
            foreach (var num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }
        }
    }
}