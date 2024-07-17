using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilevelInheritanceDemo.Models
{
    internal class Manager : Employee
    {
        public void Manage()
        {
            Console.WriteLine($"{Name} is managing the team at {Company}.");
        }
    }
}
