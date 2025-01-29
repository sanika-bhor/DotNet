// See https://aka.ms/new-console-template for more information
using ORMEntityFramework;

Console.WriteLine("Hello, World!");

IDbManager dbm=new DbProductManager();
bool status=true;

while(status)
{
    Console.WriteLine("\n1. GetAll");
    Console.WriteLine("2. get By ID");
    Console.WriteLine("3. insert");
    Console.WriteLine("4. update");
    Console.WriteLine("5. delete");
    Console.WriteLine("6. Exit");

    Console.WriteLine("\n\n\n Enter choice");
    int ch= int.Parse(Console.ReadLine());

    switch(ch)
    {
        case 1:
           List<Product> products= dbm.GetAll();
           foreach(Product p in products)
           {
                Console.WriteLine(p.ProductId + "  " + p.Title+"  "+ p.Description + "  " + p.Unitprice + "  " + p.Quantity);

            }
            break;

        case 2:
            Console.WriteLine("Enter id of product to find");
            int id=int.Parse(Console.ReadLine());
            Product product=dbm.GetById(id);

            if(product!=null)
            {
            Console.WriteLine(product.ProductId + "  " + product.Title + "  " + product.Description + "  " + product.Unitprice + "  " + product.Quantity);
            }
            else
            {
                Console.WriteLine("Product not found");
            }
            break;

        case 3:
        Console.WriteLine("Enter product id");
        int pid=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter product title");
        string title=Console.ReadLine();
        Console.WriteLine("Enter product description");
        string desc=Console.ReadLine();
        Console.WriteLine("Enter product unit price");
        int up=int.Parse(Console.ReadLine());
        Console.WriteLine("Enter product quantity");
        int quan=int.Parse(Console.ReadLine());

            Product product1=new Product
            {
                ProductId=pid,
                Title=title,
                Description=desc,
                Unitprice=up,
                Quantity=quan
            };

          bool statusInsert=  dbm.Insert(product1);

          if(statusInsert)
          {
            Console.WriteLine("Product inserted successfully");
          }
          else
          {
            Console.WriteLine("Product not inserted");
          }

            break;

        case 4:
            Console.WriteLine("Enter product id");
            int updateProductId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product title");
            string updateProducttitle = Console.ReadLine();
            Console.WriteLine("Enter product description");
            string updateProductdesc = Console.ReadLine();
            Console.WriteLine("Enter product unit price");
            int updateProductup = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product quantity");
            int updateProductquan = int.Parse(Console.ReadLine());

            Product product2 = new Product
            {
                ProductId = updateProductId,
                Title = updateProducttitle,
                Description = updateProductdesc,
                Unitprice = updateProductup,
                Quantity = updateProductquan
            };

            bool statusUpdate = dbm.Update(product2);

            if (statusUpdate)
            {
                Console.WriteLine("Product update successfully");
            }
            else
            {
                Console.WriteLine("Product not update");
            }

            break;



        case 6:
            status=false;
            break;
    }
}





//dotnet add package Microsoft.EntityFrameworkCore
//dotnet add package Microsoft.EntityFrameworkCore.Design
//dotnet add package Mysql.Data.EntityFrameworkCore --version 8.0.20