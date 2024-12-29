using Catalog;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DAL
{
    public class CatelogDbDisConnectedManager:ICatelogDbManager
    {
        public static IDbConnection dbConnection()
        {
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = @"server=localhost;port=3306;user=root;password=root123;database=ecommerce";
            return conn;
        }

        List<Product> ICatelogDbManager.getAllProductFromDB()
        {
            List<Product> products = new List<Product>();
            IDbConnection conn = CatelogDbDisConnectedManager.dbConnection();
            IDbCommand cmd = new MySqlCommand();
            string query = "select * from product";
            cmd.CommandText = query;
            cmd.Connection = conn;

            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd as MySqlCommand);
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];

                foreach(DataRow dr in dt.Rows)
                {
                    int id = int.Parse(dr["ProductId"].ToString());
                    string title = dr["Title"].ToString();
                    string description = dr["Description"].ToString();
                    int unitPrice = int.Parse(dr["UnitPrice"].ToString());
                    int quntity = int.Parse(dr["Quantity"].ToString());

                    Product product = new Product(id, title, description, quntity, unitPrice);

                    products.Add(product);
                }

            }
            catch (SqlException exp)
            {
                string msg = exp.Message;
                Console.WriteLine(msg);
            }
            finally
            {
              
            }

            return products;
        }
       
        List<Product> ICatelogDbManager.getSoldProductsFromDb()
        {
            List<Product> SoldProduct = new List<Product>();
            IDbConnection conn = CatelogDbConnectedManager.dbConnection();

            IDbCommand cmd = new MySqlCommand();
            string query = "select * from product where Quantity = 0";
            cmd.Connection = conn;
            cmd.CommandText = query;

            IDataReader reader = null;
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["ProductId"].ToString());
                        string title = reader["Title"].ToString();
                        string description = reader["description"].ToString();
                        int unitPrice = int.Parse(reader["UnitPrice"].ToString());
                        int quantity = int.Parse(reader["Quantity"].ToString());

                        Product product = new Product(id, title, description, quantity, unitPrice);

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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return SoldProduct;
        }

        bool ICatelogDbManager.insertProduct(Product p)
        {
            bool status = false;
            IDbConnection conn = CatelogDbConnectedManager.dbConnection();
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return status;
        }

        bool ICatelogDbManager.deleteProduct(int id)
        {
            bool status = false;
            IDbConnection conn = CatelogDbConnectedManager.dbConnection();
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
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return status;
        }

        Product ICatelogDbManager.getProductById(int id)
        {
           Product product = null;

            IDbConnection conn = new MySqlConnection();
            IDbCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            string query = "select * from product";
            cmd.CommandText= query;

            try
            {
                DataSet ds=new DataSet();
                MySqlDataAdapter da=new MySqlDataAdapter(cmd as MySqlCommand);
                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                DataColumn[] dc = new DataColumn[1];
                dc[0]=ds.Tables[0].Columns["ProductId"];
                ds.Tables[0].PrimaryKey = dc;

                //use dt --try 

                DataRow dr = dt.Rows.Find(id);
                if (dr != null)
                {
                    int pid = int.Parse(dr["ProductId"].ToString());
                    string title=dr["Title"].ToString();
                    string desciption=dr["Description"].ToString();
                    int price = int.Parse(dr["UnitPrice"].ToString());
                    int quantity = int.Parse(dr["Quantity"].ToString());

                    product = new Product
                    {
                        Id = pid,
                        Tittle = title,
                        Discription = desciption,
                        UnitPrice = price,
                        Quantity = quantity
                    };


                }
                else
                {
                    Console.WriteLine("Product not found");
                }

                da.Update(ds);
            }
            catch(SqlException exp)
            {
                string msg=exp.Message;
                Console.WriteLine(msg);
            }

            return product;

        }

        bool ICatelogDbManager.UpdateProduct(Product p)
        {
            bool status = false;
            IDbConnection conn = CatelogDbConnectedManager.dbConnection();
            IDbCommand cmd = new MySqlCommand();
            //string query = "insert into product(ProductId,Title,Description,UnitPrice,Quantity) values(@id,@title,@Discription, @UnitPrice,@Quantity)";
            string query = "update product set Title=@title, Description=@description, UnitPrice=@unitPrice, Quantity=@quantity where ProductId=@id";
            cmd.Connection = conn;
            cmd.CommandText = query;

            cmd.Parameters.Add(new MySqlParameter("@id", p.Id));
            cmd.Parameters.Add(new MySqlParameter("@title", p.Tittle));
            cmd.Parameters.Add(new MySqlParameter("@description", p.Discription));
            cmd.Parameters.Add(new MySqlParameter("@unitPrice", p.UnitPrice));
            cmd.Parameters.Add(new MySqlParameter("@quantity", p.Quantity));


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
            catch (MySqlException exp)
            {
                string msg = exp.Message;
                Console.WriteLine(msg);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return status;
        }
    }
}
