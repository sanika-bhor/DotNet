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
            List<Product> allProduct = BusinessManager.getAllProducts();
            foreach(Product p in allProduct)
            {
                Console.WriteLine(p.Tittle);
            }
        }
    }
}
