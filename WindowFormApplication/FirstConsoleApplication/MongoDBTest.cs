using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog;
using BLL;
using CRM;

namespace FirstConsoleApplication
{
    public class MongoDBTest
    {
        public static void Main(string[] args)
        {
            List<Customer> custmer= new List<Customer>();
            custmer = MongooDBBusinessManager.getAllDbProducts();
            foreach (Customer product in custmer)
            {
                Console.WriteLine(product.LoginId+"  "+product.Password);
            }
        }
    }

}
