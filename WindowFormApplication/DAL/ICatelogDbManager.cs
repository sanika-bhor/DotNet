using Catalog;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace DAL
{
     public interface ICatelogDbManager
    {

         List<Product> getAllProductFromDB();

         List<Product> getSoldProductsFromDb();

         bool insertProduct(Product p);

         bool deleteProduct(int id);

        Product getProductById(int id);
        
        bool UpdateProduct(Product p);
    }
}

