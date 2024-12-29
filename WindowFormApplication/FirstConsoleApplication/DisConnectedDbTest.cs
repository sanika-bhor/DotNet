using BLL;
using Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApplication
{
    public class DisConnectedDbTest
    {
        public static void Main(string[] args)
        {
           Console.WriteLine("product data");
            List<Product> all = BusinessManagerForDisConnected.getAllDbProducts();
            foreach (Product p in all)
            {
                Console.WriteLine(p.Id + "  " + p.Tittle);
            }



           /* Console.WriteLine("\nsold products: ");
            List<Product> soldProducts = BusinessManagerForConnected.getSoldProductsFromDb();
            foreach (Product p in soldProducts)
            {
                Console.WriteLine(p.Id + "  " + p.Tittle);
            }*/



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

              bool insertStatus = BusinessManagerForDisConnected.insertProductInDb(product);
              if(insertStatus)
              {
                  Console.WriteLine("Product inserted successfully");
              }
              else
              {
                  Console.WriteLine("Product not inserted successfully");
              }

            
            
            
              /* Console.WriteLine("\ndelete existing products: ");
              Console.WriteLine("Enter product id");
              int Productid = int.Parse(Console.ReadLine());

              bool deleteResult = BusinessManagerForDisConnected.deleteFromProduct(Productid);
              if(deleteResult)
              {
                  Console.WriteLine("Product deleted successfully");
              }
              else
              {
                  Console.WriteLine("Product not deleted ");
              }
              */
            
            
            
            
            /*Console.WriteLine("\nget products by id: ");
             Console.WriteLine("Enter product id");
             int id = int.Parse(Console.ReadLine());
            
             Product product = BusinessManagerForDisConnected.getProductById(id);
             Console.WriteLine(product.Id+"  "+product.Tittle+"  "+product.Discription+"  "+product.UnitPrice+"  "+product.Quantity);
            */





         /*   Console.WriteLine("\nUpdate existing products by its id: ");
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

            bool insertStatus = BusinessManagerForConnected.UpdateProductById(product);
            if (insertStatus)
            {
                Console.WriteLine("Product update successfully");
            }
            else
            {
                Console.WriteLine("Product not update");
            }*/
        }
    }
}
