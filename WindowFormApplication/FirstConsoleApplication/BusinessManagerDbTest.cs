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
                Console.WriteLine(p.Id+"  "+p.Tittle);
            }

            Console.WriteLine("\nsold products: ");
            List<Product> soldProducts = BusinessManager.getSoldProductsFromDb();
            foreach (Product p in soldProducts)
            {
                Console.WriteLine(p.Id + "  " + p.Tittle);
            }


            Console.WriteLine("\ninsert new products: ");
            Console.WriteLine("Enter product id");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter product Title");
            string title = Console.ReadLine();

            Console.WriteLine("Enter product description");
            string description = Console.ReadLine();

            Console.WriteLine("Enter product Quantity");
            int quantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter product unit Price");
            int unitPrice = int.Parse(Console.ReadLine());

            Product product = new Product
            {
                Id = id,
                Tittle = title,
                Discription = description,
                UnitPrice = unitPrice,
                Quantity = quantity
            };

            bool insertStatus = BusinessManager.insertProductInDb(product);
            if(insertStatus)
            {
                Console.WriteLine("Product inserted successfully");
            }
            else
            {
                Console.WriteLine("Product not inserted successfully");
            }
        }
    }
}
