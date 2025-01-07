using System.Data;
using System.Data.SqlTypes;
using Catelog;
using MySql.Data.MySqlClient;

namespace DAL;
public class ProductDALManager
{
    public static IDbConnection dbConnection()
    {
        IDbConnection conn = new MySqlConnection();
        conn.ConnectionString = @"server=localhost;port=3306;user=root;password=root123;database=ecommerce";
        return conn;
    }

    public static List<Product> getAllProductFromDB()
    {
        Console.WriteLine("Starting");
        List<Product> products = new List<Product>();
        IDbConnection conn = ProductDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "select * from product";
        cmd.CommandText = query;
        cmd.Connection = conn;

        IDataReader reader = null;


        try
        {
            Console.WriteLine("connection not open");
            conn.Open();
            Console.WriteLine("connection open");

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = int.Parse(reader["ProductId"].ToString());
                string title = reader["Title"].ToString();
                string description = reader["Description"].ToString();
                int unitPrice = int.Parse(reader["UnitPrice"].ToString());
                int quntity = int.Parse(reader["Quantity"].ToString());
                string image = reader["Image"].ToString();


                Product product = new Product
                {
                    ProductId = id,
                    ProductName = title,
                    Description = description,
                    UnitPrice = unitPrice,
                    Quantity = quntity,
                    Image = image
                };

                products.Add(product);
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

        return products;
    }


    public static Product getProductById(int pid)
    {

        Product product = null;
        IDbConnection conn = ProductDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "select * from product where ProductId=@pid";
        cmd.Parameters.Add(new MySqlParameter("@pid", pid));
        cmd.CommandText = query;
        cmd.Connection = conn;

        IDataReader reader = null;


        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();
            reader.Read();
            int id = int.Parse(reader["ProductId"].ToString());
            string title = reader["Title"].ToString();
            string description = reader["Description"].ToString();
            int unitPrice = int.Parse(reader["UnitPrice"].ToString());
            int quntity = int.Parse(reader["Quantity"].ToString());
            string image = reader["Image"].ToString();


            product = new Product
            {
                ProductId = id,
                ProductName = title,
                Description = description,
                UnitPrice = unitPrice,
                Quantity = quntity,
                Image = image
            };
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

        return product;

    }

    public static bool deleteProductById(int id)
    {
        bool status = false;
        IDbConnection conn = ProductDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "delete from product where ProductId=@id";
        cmd.Parameters.Add(new MySqlParameter("@id", id));
        cmd.CommandText = query;
        cmd.Connection = conn;

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            status = true;
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

    public static bool insertProduct(Product product)
    {
        bool status = false;
        IDbConnection conn = ProductDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "insert into product values(@productid, @title, @descriptpion, @unitprice, @quantity, @image)";
        cmd.Parameters.Add(new MySqlParameter("@productid", product.ProductId));
        cmd.Parameters.Add(new MySqlParameter("@title", product.ProductName));
        cmd.Parameters.Add(new MySqlParameter("@descriptpion", product.Description));
        cmd.Parameters.Add(new MySqlParameter("@unitprice", product.UnitPrice));
        cmd.Parameters.Add(new MySqlParameter("@quantity", product.Quantity));
        cmd.Parameters.Add(new MySqlParameter("@image", product.Image));

        cmd.CommandText = query;
        cmd.Connection = conn;

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            status = true;
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


    public static bool UpdateProduct(Product p)
    {
        bool status = false;
        IDbConnection conn = ProductDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "update product set Title=@title, Description=@description, UnitPrice=@unitPrice, Quantity=@quantity, Image=@image where ProductId=@id";
        cmd.Connection = conn;
        cmd.CommandText = query;

        cmd.Parameters.Add(new MySqlParameter("@id", p.ProductId));
        cmd.Parameters.Add(new MySqlParameter("@title", p.ProductName));
        cmd.Parameters.Add(new MySqlParameter("@description", p.Description));
        cmd.Parameters.Add(new MySqlParameter("@unitPrice", p.UnitPrice));
        cmd.Parameters.Add(new MySqlParameter("@quantity", p.Quantity));
        cmd.Parameters.Add(new MySqlParameter("@image", p.Image));


        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            status = true;
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