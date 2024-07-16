using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMIApp.Models;

namespace BMIApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BMI bmi1 = new BMI(101,"abc",22,1.79,92);
            BMI bmi2 = new BMI(102, "def", 22);

            DisplayBMIAndBodyType(bmi1);
            DisplayBMIAndBodyType(bmi2);
        }
        static void DisplayBMIAndBodyType(BMI bmi)
        {
            double bmiValue = BMI.CalculateBMI(bmi.Height, bmi.Weight);
            string bodyType = BMI.GetBodyType(bmiValue);
            Console.WriteLine($"{bmi}BMI of {bmi.Name}: {bmiValue:F2}\n{bodyType}\n");
        }
    }
}
