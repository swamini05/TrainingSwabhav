using System;
class PrimeNumber
{
	public static void Main(String [] args)
	{	
		Console.Write("Enter the Number: ");
		int myNumber = Convert.ToInt32(Console.ReadLine()); 
		int flag = 0;
		
		if(myNumber == 0 || myNumber == 1)
		{
			Console.WriteLine("Neither Prime nor Composite");
		}
		else
		{
			for(int i=2; i<=(Math.Sqrt(myNumber)); i++)
			{
				if(myNumber%i == 0)
				{
					flag=1;
					break;
				}
			}
		}
		if(flag == 0)
		{
			Console.WriteLine(myNumber+" is Prime Number");
		}
		else
		{
			Console.WriteLine(myNumber+" is not Prime Number");
		}
	}
}
