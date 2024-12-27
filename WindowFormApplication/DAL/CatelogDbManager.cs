using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using Catalog;
using MySql.Data.MySqlClient;


namespace DAL
{
    public class CatelogDbManager
    {
        public static IDbConnection dbConnection()
        {
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = @"server=localhost;port=3306;user=root;password=root123;database=ecommerce";
            return conn;
        }

        public static List<Product> getAllProductFromDB()
        {
            List<Product> products = new List<Product>();
            IDbConnection conn=CatelogDbManager.dbConnection();
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

        public static List<Product> getSoldProductsFromDb()
        {
            List<Product> SoldProduct = new List<Product>();
            IDbConnection conn = CatelogDbManager.dbConnection();

            IDbCommand cmd = new MySqlCommand();
            string query = "select * from product where Quantity = 0";
            cmd.Connection = conn;
            cmd.CommandText = query;

            IDataReader reader = null; 
            try
            {
                conn.Open();
                if(conn.State==ConnectionState.Open)
                {
                    reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        int id = int.Parse(reader["ProductId"].ToString());
                        string title = reader["Title"].ToString();
                        string description = reader["description"].ToString();
                        int unitPrice = int.Parse(reader["UnitPrice"].ToString());
                        int quantity = int.Parse(reader["Quantity"].ToString());

                        Product product=new Product(id,title, description, quantity, unitPrice);

                        SoldProduct.Add(product);
                    }
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
            return SoldProduct;
        }

        public static bool insertProduct(Product p)
        {
            bool status = false;
            int id = p.Id;
            Console.WriteLine(id);
            IDbConnection conn = CatelogDbManager.dbConnection();
            IDbCommand cmd = new MySqlCommand();
            string query = "insert into product values('id','p.Tittle','p.Discription', 'p.Quantity','p.UnitPrice')";
            cmd.Connection = conn;
            cmd.CommandText = query;


            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    status = true;
                }
            }
            catch (SqlException exp)
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
            return status;
        }

    }
}