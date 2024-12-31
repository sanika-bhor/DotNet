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
        
        public static IMongoDatabase getDatabase()
        {
            var _dbClient=MongoDBCatelogManager.dbConnection();
            return _dbClient.GetDatabase("ECommerce");
        }

        public static IMongoCollection<Customer> getCollection()
        {
            var db=MongoDBCatelogManager.getDatabase();
            return db.GetCollection<Customer>("Customer");
        }

        public List<Customer> getAllCustomerFromDB()
        {
            List<Customer> customers = new List<Customer>();
            var collection = MongoDBCatelogManager.getCollection();

            collection.Find(_ => true).ToList().ForEach(
                cust =>
                {
                    customers.Add(cust);
                });
            return customers;

        }

        public Customer getCutomerByName(string name)
        {
            var collection=MongoDBCatelogManager.getCollection();
            Customer cust = new Customer();
            collection.Find<Customer>(_ => true).ToList().ForEach
                (
                customer => 
                    { 
                        if(customer.Name==name)
                        {
                            cust = customer;
                        }
                    }
                );
            return cust;
        }

        public bool insertCustomer(Customer customer)
        {
            bool status = false;
           var collection= MongoDBCatelogManager.getCollection();
            if (customer != null)
            {
                collection.InsertOne(customer);
                status = true;
            }
            return status;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool status = false;
            Customer existingCustomer;
            var collection = MongoDBCatelogManager.getCollection();

            if (customer != null)
            {
                

                collection.FindOneAndUpdate<Customer>(Builders<Customer>.Filter.Eq("LoginId",customer.LoginId),
                                                     Builders<Customer>.Update.Set("Password",customer.Password)
                                                                              .Set("Email",customer.Email)
                                                                               .Set("Name",customer.Name)
                                                                               .Set("ContactNo",customer.ContactNo)
                                                                               .Set("Location",customer.Location));

                status= true;
            }
            return status;
        }

        public bool deleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
