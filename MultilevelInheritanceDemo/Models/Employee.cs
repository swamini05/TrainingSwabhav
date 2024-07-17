using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultilevelInheritanceDemo.Models
{
    internal class Employee : Person
    {
        public string Company { get; set; }

        public void Work()
        {
            Console.WriteLine($"{Name} is working at {Company}.");
        }
    }
}
