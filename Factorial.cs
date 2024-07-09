using System;
class Factorial
{
	public static void Main(String [] args)
	{
		Console.Write("Enter the Number: ");
		int myNumber = Convert.ToInt32(Console.ReadLine());
		
		int factorial = 1;
		if( myNumber<0 )
		{
			Console.WriteLine("You have entered a Negative Number");
		}
		else
		{
			for(int i=1; i<=myNumber; i++)
			{
				factorial *= i;
			}

			Console.WriteLine("Factorial of "+myNumber+" is "+factorial);
		}
		
	}
}
