using System;  
public class ReversedNumber 
{  
    public static void Main(string[] args)  
    {  
        int  myNumber, reversedNumber=0, rem;   
        
        Console.Write("Enter a number: ");      
        myNumber = Convert.ToInt32(Console.ReadLine());

        while(myNumber!=0)      
        {      
            rem = myNumber%10;        
            reversedNumber = reversedNumber*10 + rem;      
            myNumber /= 10;      
        }   
   
        Console.Write("Reversed Number: "+reversedNumber);       
    }  
}