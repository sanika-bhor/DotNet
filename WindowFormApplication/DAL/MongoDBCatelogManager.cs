using Catalog;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using CRM;

namespace DAL
{
    public class MongoDBCatelogManager
    {
        public static MongoClient dbConnection()
        {
            return new MongoClient("mongodb://localhost:27017/");
        }
        public bool deleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> getAllProductFromDB()
        {
            List<Customer> customers = new List<Customer>();
            var _dbClient=MongoDBCatelogManager.dbConnection();
            var db = _dbClient.GetDatabase("ECommerce");
            var collection = db.GetCollection<Customer>("Customer");

            collection.Find(_ => true).ToList().ForEach(
                cust =>
                {
                    customers.Add(cust);
                });
            return customers;

        }

        public Product getProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> getSoldProductsFromDb()
        {
            throw new NotImplementedException();
        }

        public bool insertProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
