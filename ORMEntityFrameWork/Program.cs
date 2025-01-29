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

        case 6:
            status=false;
            break;
    }
}





//dotnet add package Microsoft.EntityFrameworkCore
//dotnet add package Microsoft.EntityFrameworkCore.Design
//dotnet add package Mysql.Data.EntityFrameworkCore --version 8.0.20