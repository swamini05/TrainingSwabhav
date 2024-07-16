using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grade myVar = Grade.B;
            switch (myVar)
            {
                case Grade.A:
                    Console.WriteLine("Great!");
                    break;
                case Grade.B:
                    Console.WriteLine("Keep it up!");
                    break;
                case Grade.C:
                    Console.WriteLine("Work Harder!");
                    break;
            }
            Console.WriteLine((int)myVar);
        }
    }
}
