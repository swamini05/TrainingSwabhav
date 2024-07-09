using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProject
{
    internal class Fibonacci
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter a number");
            int inputLength=Convert.ToInt32(Console.ReadLine());
            GetFibonacci(0,1,1,inputLength);
         
	    }
        static void GetFibonacci(int a,int b,int counter ,int inputLength1)
        {
            if (counter <= inputLength1)
            {
                Console.Write("{0} ",a);
                GetFibonacci(b, a + b, counter + 1, inputLength1);
            }
        }
           

    }   
    
}
