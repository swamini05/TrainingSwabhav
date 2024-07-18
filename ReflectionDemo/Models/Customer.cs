using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Customer() { }

        public void AddAccount(Account account) { }
        public void RemoveAccount(Account account) { }
    }
}
