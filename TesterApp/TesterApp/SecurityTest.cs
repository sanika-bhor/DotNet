using MemberShip;
using System;

//each project have only one main function at a time for running
//for that-
//rightlink on project ->property -> application -> setup object -> select start up project
namespace TesterApp
{
    public class SecurityTest
    {
        public static void Main()
        {

            //unit test for login page
            Console.WriteLine("enter login id: ");
            string loginId=Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            string password=Console.ReadLine();

            bool status= AccountManager.Login(loginId,password);
            if(status)
            {
                Console.WriteLine("welcome");
            }
            else
            {
                Console.WriteLine("Inavlid useer");
            }

            //unit test for register page
            Console.WriteLine("enter login id: ");
             loginId = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
             password = Console.ReadLine();

            Console.WriteLine("Enter name: ");
            string name=Console.ReadLine();

            Console.WriteLine("Enter Email: ");
            string email=Console.ReadLine();

            Console.WriteLine("contact no: ");
            string contact=Console.ReadLine();

            Console.WriteLine("location: ");
            string location=Console.ReadLine();

             status=AccountManager.Register(loginId,password,name,email,contact,location);

            if (status)
            {
                Console.WriteLine("register successfully");
            }
            else
            {
                Console.WriteLine("failed to register");
            }




        }
    }
}
