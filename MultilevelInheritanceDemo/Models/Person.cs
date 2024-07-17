using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo.Models
{
    internal class Person
    {
        public string Name { get; set; }

        public void Introduce()
        {
            Console.WriteLine($"Hello, my name is {Name}.");
        }
    }
}
