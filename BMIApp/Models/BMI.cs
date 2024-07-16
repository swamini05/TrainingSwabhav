using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIApp.Models
{
    internal class BMI
    {
        private int _id;
        private string _name;
        private int _age;
        private double _height;
        private double _weight;
        static double DEFAULT_HEIGHT = 1.5;
        static double DEFAULT_WEIGHT = 50;

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public double Height { get { return _height; } set { _height = value; } }
        public double Weight { get { return _weight; } set { _weight = value; } }
        public BMI(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
            Height = DEFAULT_HEIGHT;
            Weight = DEFAULT_WEIGHT;
        }
        public BMI(int id, string name, int age, double height, double weight):this(id, name,age)
        {   
            Height = height;
            Weight = weight;
        }
        public static double CalculateBMI(double height,double weight)
        {
            return weight/(height*height);
        }
        public static string GetBodyType(double bmi)
        {
            if (bmi < 18.5)
            {
                return "Underweight";
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                return "Normal";
            }
            else if (bmi >= 25 && bmi < 30)
            {
                return "Overweight";
            }
            else
            {
                return "Obese";
            }
        }
        public override string ToString()
        {
            return $"===========User Id. {Id}===========\n" +
                $"User Name: {Name}\n" +
                $"Age: {Age}\n"+
                $"Height: {Height}\n" +
                $"Weight: {Weight}\n";
        }
    }
}
