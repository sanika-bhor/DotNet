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
            return SoldProduct;
        }

        bool ICatelogDbManager.insertProduct(Product p)
        {
            bool status = false;
            IDbConnection conn = CatelogDbConnectedManager.dbConnection();
            IDbCommand cmd = new MySqlCommand();
            string query = "select * from product";
            cmd.Connection = conn;
            cmd.CommandText = query;
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
                MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder();
                da.Fill(ds);


                DataRow dr = ds.Tables[0].NewRow();
                dr["ProductId"]=p.Id;
                dr["Title"] = p.Tittle;
                dr["Description"] = p.Discription;
                dr["UnitPrice"]=p.UnitPrice;
                dr["Quantity"]=p.Quantity;

                ds.Tables[0].Rows.Add(dr);

                da.Update(ds);
                status = true;
                

            }
            catch (SqlException exp)
            {
                string msg = exp.Message;
                Console.WriteLine(msg);
            }

            return status;
        }

        bool ICatelogDbManager.deleteProduct(int id)
        {
            bool status = false;
            IDbConnection conn = CatelogDbConnectedManager.dbConnection();
            IDbCommand cmd = new MySqlCommand();
            string query = "select * from product";
            cmd.Parameters.Add(new MySqlParameter("@Id", id));
            cmd.Connection = conn;
            cmd.CommandText = query;
            try
            {
                DataSet ds=new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                DataColumn[] col = new DataColumn[1];
                col[0]=ds.Tables[0].Columns["ProductId"];
                ds.Tables[0].PrimaryKey = col;

                DataRow dr= dt.Rows.Find(id);
                if (dr != null)
                {
                    dr.Delete();
                    status = true;
                }     
            da.Update(ds);

            }
            catch (SqlException exp)
            {
                string msg = exp.Message;
                Console.WriteLine(msg);
            }

            return status;
        }

        Product ICatelogDbManager.getProductById(int id)
        {
           Product product = null;

            IDbConnection conn = CatelogDbDisConnectedManager.dbConnection();
            IDbCommand cmd = new MySqlCommand();
            string query = "select * from product";

            cmd.Connection = conn;
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
            string query = "select * from product";
            cmd.Connection = conn;
            cmd.CommandText = query;
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
                MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder();
                da.Fill(ds);


                DataColumn[] col = new DataColumn[1];
                col[0] = ds.Tables[0].Columns["ProductId"];
                ds.Tables[0].PrimaryKey = col;

                DataRow Existingdr = ds.Tables[0].Rows.Find(p.Id);
                if (Existingdr != null)
                {
                    Existingdr.Delete();
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["ProductId"] = p.Id;
                    dr["Title"] = p.Tittle;
                    dr["Description"] = p.Discription;
                    dr["UnitPrice"] = p.UnitPrice;
                    dr["Quantity"] = p.Quantity;

                    ds.Tables[0].Rows.Add(dr);

                    da.Update(ds);
                    status = true;
                }
              

            }
            catch (SqlException exp)
            {
                string msg = exp.Message;
                Console.WriteLine(msg);
            }

            return status;
        }
    }
}
