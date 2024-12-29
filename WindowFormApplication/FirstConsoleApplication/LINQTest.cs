using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog;
using BLL;

namespace FirstConsoleApplication
{
    public class LINQTest
    {
        public static void Main(string[] args)
        {
            List<Product> allProduct = BusinessManagerForConnected.getAllProducts();
            Console.WriteLine("All Products: ");
            foreach(Product p in allProduct)
            {
                Console.WriteLine(p.Tittle);
            }

            IEnumerable<Product> soldProduct = BusinessManagerForConnected.getSoldProducts();
            Console.WriteLine("\nSold Products: ");
            foreach (Product p in soldProduct)
            {
                Console.WriteLine(p.Tittle);
            }
        }
    }
}
