using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    public class EventHandlingTest
    {
        static void Main(string[] args)
        {
                          
            Account acc = new Account(500);

            acc.overBalance += new AccountHandler(GovernmentPolicy.payIncomeTax);
            acc.underBalance += new AccountHandler(BankPolicy.blockAccount);

            Console.WriteLine("Initial balance:{0} ", acc.Balance);

            Console.WriteLine("\n enter balance to deposite: ");
            int amount = int.Parse(Console.ReadLine());
            acc.deposite(amount);
            Console.WriteLine("after deposite: {0}", acc.Balance);

            Console.WriteLine("\n enter balance to withdraw: ");
             amount = int.Parse(Console.ReadLine());
            acc.withdraw(amount);
            Console.WriteLine("after withdraw: {0}", acc.Balance);

        }
    }
}
