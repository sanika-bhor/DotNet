using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class Account
    {
        private float balance;

        public Account(float Amount) {
            this.balance = Amount;
        }

        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }


        public void withdraw(float amount)
        {
            balance = balance - amount;
        }

        public void deposite(float amount)
        {
            balance = balance + amount;
        }
    }
}
