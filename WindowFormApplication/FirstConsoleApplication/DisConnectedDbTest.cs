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
            int ch;
            char choice;
            do
            {
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine("1.Get All Products");
                Console.WriteLine("2.Get All Sold Products");
                Console.WriteLine("3.Get Products by id");
                Console.WriteLine("4.Insert");
                Console.WriteLine("5.Update");
                Console.WriteLine("6.Delete");
                ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.WriteLine("product data");
                        List<Product> all = BusinessManagerForDisConnected.getAllDbProducts();
                        foreach (Product p in all)
                        {
                            Console.WriteLine(p.Id + "  " + p.Tittle);
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nsold products: ");
                        List<Product> soldProducts = BusinessManagerForConnected.getSoldProductsFromDb();
                        foreach (Product p in soldProducts)
                        {
                            Console.WriteLine(p.Id + "  " + p.Tittle);
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nget products by id: ");
                         Console.WriteLine("Enter product id");
                         int id = int.Parse(Console.ReadLine());
            
                         Product product = BusinessManagerForDisConnected.getProductById(id);
                         Console.WriteLine(product.Id+"  "+product.Tittle+"  "+product.Discription+"  "+product.UnitPrice+"  "+product.Quantity);
            
                        break;

                    case 4:
                         Console.WriteLine("\ninsert new products: ");
                         Console.WriteLine("Enter product id");
                         int Newid = int.Parse(Console.ReadLine());

                         Console.WriteLine("Enter product Title");
                         string Newtitle = Console.ReadLine();

                         Console.WriteLine("Enter product description");
                         string Newdescription = Console.ReadLine();

                         Console.WriteLine("Enter product Quantity");
                         int Newquantity = int.Parse(Console.ReadLine());

                         Console.WriteLine("Enter product unit Price");
                         int NewunitPrice = int.Parse(Console.ReadLine());

                         Product Newproduct = new Product
                         {
                             Id = Newid,
                             Tittle = Newtitle,
                             Discription = Newdescription,
                             UnitPrice = NewunitPrice,
                             Quantity = Newquantity
                         };

                         bool insertStatus = BusinessManagerForDisConnected.insertProductInDb(Newproduct);
                         if(insertStatus)
                         {
                             Console.WriteLine("Product inserted successfully");
                         }
                         else
                         {
                             Console.WriteLine("Product not inserted successfully");
                         }
                        break;

                    case 5:
                        Console.WriteLine("\nUpdate existing products by its id: ");
                          Console.WriteLine("Enter product id");
                          int Updatedid = int.Parse(Console.ReadLine());

                          Console.WriteLine("Enter product Title");
                          string Updatedtitle = Console.ReadLine();

                          Console.WriteLine("Enter product description");
                          string Updateddescription = Console.ReadLine();

                          Console.WriteLine("Enter product Quantity");
                          int Updatedquantity = int.Parse(Console.ReadLine());

                          Console.WriteLine("Enter product unit Price");
                          int UpdatedunitPrice = int.Parse(Console.ReadLine());

                          Product Updatedproduct = new Product
                          {
                              Id = Updatedid,
                              Tittle = Updatedtitle,
                              Discription = Updateddescription,
                              UnitPrice = UpdatedunitPrice,
                              Quantity = Updatedquantity
                          };

                          bool UpdatedStatus = BusinessManagerForDisConnected.UpdateProductById(Updatedproduct);
                          if (UpdatedStatus)
                          {
                              Console.WriteLine("Product update successfully");
                          }
                          else
                          {
                              Console.WriteLine("Product not update");
                          }
                        break;

                    case 6:
                        Console.WriteLine("\ndelete existing products: ");
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
                        break;

                    default:
                        Console.WriteLine("THANK YOU!!");
                        break;

                }
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("please enter 'y' to continue");
                 choice=char.Parse(Console.ReadLine());

            } while (choice == 'Y' || choice == 'y');        
        }
    }
}
