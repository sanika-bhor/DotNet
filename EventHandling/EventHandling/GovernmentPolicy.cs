using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    public static class GovernmentPolicy
    {
        public static void payIncomeTax()
        {
            Console.WriteLine("5% tax is deducted from your account");
        }
        public static void payServiceTax()
        {
            Console.WriteLine("10% tax is deduced from your account");
        }
        public static void enquriry()
        {
            Console.WriteLine("Government officer is come for enquiry so cooperate otherwise arrest warrent is issue against you");
        }
    }
}
