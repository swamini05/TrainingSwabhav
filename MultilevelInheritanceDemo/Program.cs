using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InheritanceDemo.Models;

namespace InheritanceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager myManager = new Manager
            {
                Name = "Swamini",
                Company = "Aurionpro"
            };

            Employee myEmployee = new Employee
            {
                Name = "Akshay",
                Company = "Exceller Tech"
            };

            myManager.Introduce();  
            myManager.Work();       
            myManager.Manage();

            myEmployee.Introduce();
            myEmployee.Work();

        }
    }
}
