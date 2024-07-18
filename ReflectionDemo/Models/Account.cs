using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.Models
{
    internal class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }

        public Account() { }

        public void Deposit(decimal amount) { }
        public void Withdraw(decimal amount) { }
    }
}
