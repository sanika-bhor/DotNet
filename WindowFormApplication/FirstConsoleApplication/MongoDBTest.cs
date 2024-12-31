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
                Console.WriteLine("3.insert new customer");
                Console.WriteLine("4.Update customer");
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
                        Console.WriteLine("LoginID: ");
                        string loginid=Console.ReadLine();

                        Console.WriteLine("Password: ");
                        string password = Console.ReadLine();


                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Email: ");
                        string email = Console.ReadLine();

                        Console.WriteLine("Contact No: ");
                        string contactno = Console.ReadLine();

                        Console.WriteLine("location: ");
                        string location = Console.ReadLine();

                        Customer newCustomer = new Customer
                        {
                            LoginId = loginid,
                            Password = password,
                            Name = name,
                            Email = email,
                            ContactNo = contactno,
                            Location = location
                        };

                      bool insertStatus=MongooDBBusinessManager.insertNewCustomer(newCustomer);
                        if (insertStatus)
                        {
                            Console.WriteLine("Product inserted Successfully ");
                        }
                        else
                        {
                            Console.WriteLine("Product not inserted");
                        }
                        break;

                    case 4:
                        Console.WriteLine("LoginID: ");
                        string updatedloginid = Console.ReadLine();

                        Console.WriteLine("Password: ");
                        string updatedpassword = Console.ReadLine();


                        Console.WriteLine("Name: ");
                        string updatedname = Console.ReadLine();

                        Console.WriteLine("Email: ");
                        string updatedemail = Console.ReadLine();

                        Console.WriteLine("Contact No: ");
                        string updatedcontactno = Console.ReadLine();

                        Console.WriteLine("location: ");
                        string updatedlocation = Console.ReadLine();

                        Customer updatedCustomer = new Customer
                        {
                            LoginId = updatedloginid,
                            Password = updatedpassword,
                            Name = updatedname,
                            Email = updatedemail,
                            ContactNo = updatedcontactno,
                            Location = updatedlocation
                        };

                        bool updatedStatus = MongooDBBusinessManager.updateCustomer(updatedCustomer);
                        if (updatedStatus)
                        {
                            Console.WriteLine("Product updated Successfully ");
                        }
                        else
                        {
                            Console.WriteLine("Product not updated");
                        }
                        break;


                }
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("please enter y to continue");
                choice=char.Parse(Console.ReadLine());
               
            } while (choice == 'Y' || choice == 'y');


        }
    }

}
