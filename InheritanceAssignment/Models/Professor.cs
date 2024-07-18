using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAssignment.Models
{
    internal class Professor:Person
    {
        public double Salary { get; set; }
        public Professor() { }
        public Professor(int id,string address,DateOnly dob,double salary):base(id,address,dob)
        {
            Salary = salary;
        }
        public override string PrintDetails()
        {
            return $"{base.PrintDetails()}\nSalary : {Salary}";
        }
    }
}
