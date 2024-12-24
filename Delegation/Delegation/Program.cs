using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegation
{
    //delegate is a keyword
    //it is of reference type
    //something which is of reference type so we have to create object of it
    //using delegate we can implement late binding
    public delegate void Handler();

    public class Program
    {
        public static void payIncomeTax()
        {
            Console.WriteLine("5% tax is deducted");
        }

        public static void payOutComeTax()
        {
            Console.WriteLine("10% tax is deducted");
        }
        public static void payServiceTax()
        {
            Console.WriteLine("15% tax is deducted");
        }
        static void Main(string[] args)
        {

            //early bidinig- which function is to be called is known at compile
            payIncomeTax();

            //late binding= whichh function is to be called is known at runtime

            //creating object of delegate
            Handler operation1 = new Handler(payIncomeTax);
            operation1();

            Handler operation2 = new Handler(payOutComeTax);
            operation2();

            Handler operation3 = new Handler(payServiceTax);
            operation3();

        }
    }
}
