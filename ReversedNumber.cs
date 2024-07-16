using System;  
public class ReversedNumber 
{  
    public static void Main(string[] args)  
    {  
        int  myNumber, reversedNumber=0, remainder;   
        
        Console.Write("Enter a number: ");      
        myNumber = Convert.ToInt32(Console.ReadLine());

        while(myNumber!=0)      
        {      
            remainder = myNumber%10;        
            reversedNumber = reversedNumber*10 + remainder;      
            myNumber /= 10;      
        }   
   
        Console.Write("Reversed Number: "+reversedNumber);       
    }  
}