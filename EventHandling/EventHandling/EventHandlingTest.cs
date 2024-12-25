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

            Console.WriteLine("Initial balance:{0} ", acc.Balance);

            acc.deposite(562);
            Console.WriteLine("after deposite: {0}", acc.Balance);

            acc.withdraw(200);
            Console.WriteLine("after withdraw: {0}", acc.Balance);

        }
    }
}
