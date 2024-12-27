using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog;

namespace FirstConsoleApplication
{
    public class BusinessManagerDbTest
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("product data");
            List<Product> all=BusinessManager.getAllDbProducts();
            foreach (Product p in all)
            {
                Console.WriteLine(p.Tittle);
            }
        }
    }
}
