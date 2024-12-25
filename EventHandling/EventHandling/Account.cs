using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    public class Account
    {
        public int Balance { get; set; }

        public Account(int balance)
        {
            this.Balance = balance;
        }

        public void withdraw(int amount)
        {
            Balance -= amount;
        }

        public void deposite(int amount)
        {
            Balance +=amount;
        }
    }
}
