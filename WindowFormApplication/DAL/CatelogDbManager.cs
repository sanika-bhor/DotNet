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
                conn.Close();


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
                conn.Close();

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
            return SoldProduct;
        }

        public static bool insertProduct(Product p)
        {
            bool status = false;
            IDbConnection conn = CatelogDbManager.dbConnection();
            IDbCommand cmd = new MySqlCommand();
            string query = "insert into product(ProductId,Title,Description,UnitPrice,Quantity) values(@id,@title,@Discription, @UnitPrice,@Quantity)";
            cmd.Connection = conn;
            cmd.CommandText = query;
            
            cmd.Parameters.Add(new MySqlParameter("@id", p.Id));
            cmd.Parameters.Add(new MySqlParameter("@title", p.Tittle));
            cmd.Parameters.Add(new MySqlParameter("@Discription", p.Discription));
            cmd.Parameters.Add(new MySqlParameter("@UnitPrice", p.UnitPrice));
            cmd.Parameters.Add(new MySqlParameter("@Quantity", p.Quantity));
          


            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                    status = true;
                }
                conn.Close();

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

        public static bool deleteProduct(int id)
        {
            bool status = false;
            IDbConnection conn = CatelogDbManager.dbConnection();
            IDbCommand cmd = new MySqlCommand();
            string query = "delete from product where ProductId =@Id";
            cmd.Parameters.Add(new MySqlParameter("@Id", id));
            cmd.Connection = conn;
            cmd.CommandText = query;
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                    status = true;
                }
                conn.Close();
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