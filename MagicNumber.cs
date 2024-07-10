using System;
class MagicNumber
{
	public static void Main(String [] args)
	{

        	const double PI = 3.141592653589793;
        	const double RECTANGLE_LENGTH = 10.0;
        	const double RECTANGLE_BREADTH = 20.0;
        	const double SQUARE_SIDE = 4.0;

        	double radius = 5.0;
        	double area = PI * radius * radius;
        	Console.WriteLine("The area of the circle is: "+area);

        	double rectangleArea = RECTANGLE_LENGTH * RECTANGLE_BREADTH;
        	Console.WriteLine("The area of the rectangle is: "+rectangleArea);

        	double squareArea = SQUARE_SIDE * SQUARE_SIDE;
        	Console.WriteLine("The area of the square is: "+squareArea);	
	}
}