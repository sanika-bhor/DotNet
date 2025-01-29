// See https://aka.ms/new-console-template for more information
using ORMEntityFramework;

Console.WriteLine("Hello, World!");

IDbManager dbm=new DbProductManager();
bool status=true;

while(status)
{
    Console.WriteLine("\n1. GetAll");

    Console.WriteLine("\n\n\n Enter choice");
    int ch= int.Parse(Console.ReadLine());

    switch(ch)
    {
        case 1:
           List<Product> products= dbm.GetAll();
           foreach(Product p in products)
           {
                Console.WriteLine("\n "+ p.ProductId + "  " + p.Title+"  "+ p.Description + "  " + p.Unitprice + "  " + p.Quantity);

            }
            break;
    }
}





//dotnet add package Microsoft.EntityFrameworkCore
//dotnet add package Microsoft.EntityFrameworkCore.Design
//dotnet add package Mysql.Data.EntityFrameworkCore --version 8.0.20