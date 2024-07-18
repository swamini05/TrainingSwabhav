using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAssignment.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateOnly DOB { get; set; }

        public Person()
        {
        }

        public Person(int id, string address, DateOnly dOB)
        {
            Id = id;
            Address = address;
            DOB = dOB;
        }

        public virtual string PrintDetails()
        {
            return $"Person Id : {Id}\n" +
                $"Person Address : {Address}\n" +
                $"Person DOB : {DOB}";
        }

    }
}
