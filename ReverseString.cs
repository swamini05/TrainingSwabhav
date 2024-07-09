using System;
class ReverseString
{
	public static void Main(String [] args)
	{
		Console.Write("Enter the String: ");
		string myString = Console.ReadLine();

		string reversedString="";

		for(int i = myString.Length-1; i>=0; i--)
		{
			reversedString += myString[i];
		}
		Console.WriteLine("Reversed String: " +reversedString);
	}
}