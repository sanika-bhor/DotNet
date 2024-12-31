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
            int ch;
            char choice;
            do
            {

                Console.WriteLine("please enter your choice: ");
                Console.WriteLine("1.get all customers");
                Console.WriteLine("2.get customer by their name");
                ch=int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch(ch)
                {
                    case 1:
                        List<Customer> custmer = new List<Customer>();
                        custmer = MongooDBBusinessManager.getAllDbProducts();
                        foreach (Customer product in custmer)
                        {
                            Console.WriteLine(product.LoginId + "  " + product.Email);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter customer details to get password");
                        string pass=Console.ReadLine();
                        Customer customer = MongooDBBusinessManager.getCustomerByName(pass);
                        Console.WriteLine("customer password:{0}",customer.Password);
                        break;

                    case 3:
                        break;

                }
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("please enter y to continue");
                choice=char.Parse(Console.ReadLine());
               
            } while (choice == 'Y' || choice == 'y');


        }
    }

}
