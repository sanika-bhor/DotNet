using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    public delegate void AccountHandler();
    public class Account
    {
        public event AccountHandler overBalance;
        public event AccountHandler underBalance;

        public int Balance { get; set; }

        public void monitor()
        {
            if(Balance<5000)
            {
                underBalance();
            }
            else if(Balance > 250000)
            {
                overBalance();
            }
        }

        public Account(int balance)
        {
            this.Balance = balance;
        }

        public void withdraw(int amount)
        {
            Balance -= amount;
            monitor();
        }

        public void deposite(int amount)
        {
            Balance +=amount;
            monitor();  
        }
    }
}
