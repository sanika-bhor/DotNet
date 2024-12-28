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
            using (Product p1 = new Product(101, "rose", "valentineflower", 503, 5))
            {
                Console.WriteLine(p1.Tittle + " " + p1.Discription);
            }
        }
    }
}
