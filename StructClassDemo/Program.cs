using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructClassDemo.Models;

namespace StructClassDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PointStruct point1 = new PointStruct(10, 20);
            PointStruct point2 = point1;

            PointClass point3 = new PointClass(10, 20);
            PointClass point4 = point3;

            point2.X = 30;
            point4.X = 30;

            Console.WriteLine("================Struct Example:================");
            point1.Display();
            point2.Display();

            Console.WriteLine("\n================Class Example:================");
            point3.Display();
            point4.Display(); 
        }
    }
}
