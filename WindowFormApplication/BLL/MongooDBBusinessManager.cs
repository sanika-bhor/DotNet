using Catalog;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM;

namespace BLL
{
    public class MongooDBBusinessManager
    {
        public static List<Customer> getAllDbProducts()
        {
            MongoDBCatelogManager manager = new  MongoDBCatelogManager();

            List<Customer> allProducts = (List<Customer>)manager.getAllCustomerFromDB();
            return allProducts;
        }

        public static Customer getCustomerByName(string name)
        {
            MongoDBCatelogManager manger = new MongoDBCatelogManager();
            Customer customer = manger.getCutomerByName(name);
            return customer;
        }

        public static bool insertNewCustomer(Customer customer)
        {
            bool status = false;
            MongoDBCatelogManager manger = new MongoDBCatelogManager();
            if (customer != null)
            {
                manger.insertCustomer(customer);
                status = true;
            }
            return status;

        }

        public static bool updateCustomer(Customer customer)
        {
            bool status = false;
            MongoDBCatelogManager manager = new MongoDBCatelogManager();
            if (customer != null)
            {
                status= manager.UpdateCustomer(customer);
            }
            return status;
        }

        public static bool deleteCustomer(string id)
        {
            bool status = false;
            MongoDBCatelogManager mgr = new MongoDBCatelogManager();
            status = mgr.deleteProduct(id);
            return status;
        }
    }

}
