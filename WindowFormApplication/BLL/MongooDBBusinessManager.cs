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

            List<Customer> allProducts = (List<Customer>)manager.getAllProductFromDB();
            return allProducts;
        }

    }
}
