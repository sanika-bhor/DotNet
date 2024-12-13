using Catalog;
using System;

//each project have only one main function at a time for running
//for that-
//rightlink on project ->property -> application -> setup object -> select start up project
namespace TesterApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product=new Product(1,"rose","valentine",25,5);
            Console.WriteLine(product);
        }
    }
}
