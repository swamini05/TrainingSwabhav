using System;

public class EnumDemo
{
	enum Grade 
	{
  		A,
  		B,
  		C
	}

	static void Main(string[] args) 
	{
  		Grade myVar = Grade.A;
  		switch(myVar) 
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
  	}
}