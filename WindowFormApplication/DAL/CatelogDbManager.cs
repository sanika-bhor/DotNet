using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Catalog;
using MySql.Data.MySqlClient;


namespace DAL
{
    public class CatelogDbManager
    {
        public static List<Product> getAllProductFromDB()
        {
            List<Product> products = new List<Product>();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = @"server=localhost;port=3306;user=root;password=root123;database=ecommerce";


            IDbCommand cmd = new MySqlCommand();
            string query = "select * from product";
            cmd.CommandText = query;
            cmd.Connection = conn;

            IDataReader reader = null;

            try
            {
                conn.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["ProductId"].ToString());
                    string title=reader["Title"].ToString();
                    string description=reader["Description"].ToString();
                    int unitPrice = int.Parse(reader["UnitPrice"].ToString());
                    int quntity = int.Parse(reader["Quantity"].ToString());

                    Product product = new Product(id,title,description, quntity, unitPrice);

                    products.Add(product);
                }
              
            }
            catch(SqlException exp)
            {
                string msg = exp.Message;
                Console.WriteLine(msg);
            }
            finally
            {
                if(conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }

            }

            return products;
        }
    }
}
