using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    public static class BankPolicy
    {
        public static void blockAccount()
        {
            Console.WriteLine("your account has been blocked due to unsufficient balance");
        }
        public static void sendEmailNotificaation()
        {
            Console.WriteLine(" notification is send to your email having all information about this");
        }
    }
}
