using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRM;

namespace MemberShip
{
    public static class AccountManager
    {
        public static bool Login(string loginID, string password)
        {
            bool status = false;
            if (loginID == "sanika_bhor" && password == "sanika")
            {
                status = true;
            }
            return status;
        }


        public static bool Register(string loginID, string password, string name, string email, int contactNo, string location)
        {
            bool status = false;
            Customer customer = new Customer();
            customer.LoginId = loginID;
            customer.Password = password;
            customer.Name = name;
            customer.Email = email;
            customer.ContactNo = contactNo;
            customer.Location = location;

            if (customer == null)
            {
                status = true;
            }
            return status;
        }

        public static bool changePassword(string loginID, string existingPassword, string newPasswoed)
        {
            bool status = false;
           
            return status;
        }

        public static bool forgetPassword(string loginID)
        {
            bool status = false;

            return status;
        }
    }
}