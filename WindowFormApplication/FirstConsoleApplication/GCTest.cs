using Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApplication
{
    public class GCTest
    {
        public static void Main(String[] args)
        {
            //***** call despose() to deallocate memory when using block completed
             using (Product p1 = new Product(101, "rose", "valentineflower", 503, 5))
             {
                 Console.WriteLine(p1.Tittle + " " + p1.Discription);
                 Console.WriteLine("Thank You");
                  //GC.SuppressFinalize(p1);

             }


            //***** call desstructor to deallocate memory
            Product p2 = new Product(101, "rose", "valentineflower", 503, 5);
            Console.WriteLine(p2.Tittle + " " + p2.Discription);
            Console.WriteLine("Thank You");
            //GC.Collect();
            //  GC.WaitForPendingFinalizers();

        }
    }
}
