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
    //it can hold a reference to the methods.
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
            Handler operation2 = new Handler(payOutComeTax);
            Handler operation3 = new Handler(payServiceTax);

            //invoking delegate
            Console.WriteLine("\nInvoking individual delegate:");
             operation1();
             operation2();
             operation3();

            //multicast handler
            Handler masterHandlerManager = null;
            masterHandlerManager += operation1;
            masterHandlerManager += operation2;
            masterHandlerManager += operation3;

            Console.WriteLine("\nInvoking multicast delegate:");
            masterHandlerManager();


            //unregister delegate
            masterHandlerManager -= operation2;
            Console.WriteLine("\nInvoking multicast delegate after unregistration:");
            masterHandlerManager();

        }
    }
}
