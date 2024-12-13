using Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterApp
{
    public class BankTest
    {
        public static void Main()
        {
            Account account = new Account(5000);
            Console.WriteLine("1.wthdraw");                                      
            Console.WriteLine("2.deposite");                                      
            Console.WriteLine("3.check balance");


            int ch; 
            do
            {
                Console.WriteLine("enter choice :");
                 ch =int.Parse( Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        account.withdraw(520);
                        break;

                    case 2:
                        account.deposite(200);
                        break;

                    case 3:
                        float amount = account.Balance;
                        Console.WriteLine(amount);
                        break;

                    default:
                        Console.WriteLine("sorry");
                        break;
                }
            } while (ch != 4);


        }
    }
}
