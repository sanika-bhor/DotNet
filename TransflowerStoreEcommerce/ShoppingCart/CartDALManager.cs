using System.Data;
using System.Data.SqlTypes;
using ShoppingCart;
using Catelog;
using MySql.Data.MySqlClient;

namespace DAL;
public class CartDALManager
{
    public static IDbConnection dbConnection()
    {
        IDbConnection conn = new MySqlConnection();
        conn.ConnectionString = @"server=localhost;port=3306;user=root;password=root123;database=ecommerce";
        return conn;
    }

    public static List<Item> getAllItemsFromDB()
    {
        List<Item> items = new List<Item>();
        IDbConnection conn = CartDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "select * from ShoppingCart";
        cmd.CommandText = query;
        cmd.Connection = conn;

        IDataReader reader = null;


        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int Productid = int.Parse(reader["ProductId"].ToString());
                int Customerid = int.Parse(reader["CustomerId"].ToString());
                string title = reader["Title"].ToString();
                int unitprice = int.Parse(reader["UnitPrice"].ToString());
                int quantity = int.Parse(reader["Quantity"].ToString());
              

                Product product =new Product{
                    ProductId=Productid,
                    ProductName=title,
                    UnitPrice=unitprice
                };

                Item item = new Item(product,quantity,Customerid);

               items.Add(item);
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

        return items;
    }

     public static Item getItemById(int cid)
    {
        Item item=null; 
        IDbConnection conn = CartDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "select * from ShoppingCart where CustomerId=@cid";
        cmd.Parameters.Add(new MySqlParameter("@cid", cid));
        cmd.CommandText = query;
        cmd.Connection = conn;

        IDataReader reader = null;


        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();
            reader.Read();
             int Productid = int.Parse(reader["ProductId"].ToString());
                int Customerid = int.Parse(reader["CustomerId"].ToString());
                string title = reader["Title"].ToString();
                int unitprice = int.Parse(reader["UnitPrice"].ToString());
                int quantity = int.Parse(reader["Quantity"].ToString());
              

                Product product =new Product{
                    ProductId=Productid,
                    ProductName=title,
                    UnitPrice=unitprice
                };

                 item = new Item(product,quantity,Customerid);

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

        return item;
    }

    public static bool insertCart(Item item)
    {
        bool status = false;

        IDbConnection conn = CartDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "insert into shoppingcart values(@productid, @customerId, @title, @unitprice, @quantity)";
        cmd.Parameters.Add(new MySqlParameter("@productid", item.product.ProductId));
        cmd.Parameters.Add(new MySqlParameter("@customerId", item.CustomerId));
        cmd.Parameters.Add(new MySqlParameter("@title", item.product.ProductName));
        cmd.Parameters.Add(new MySqlParameter("@unitprice", item.product.UnitPrice));
        cmd.Parameters.Add(new MySqlParameter("@quantity", item.Quantity));

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


    public static bool deleteItemById(int id)
    {
        bool status = false;
        IDbConnection conn = CartDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "delete from shoppingcart where CustomerId=@id";
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

    public static bool UpdateItem(Item item)
    {
        bool status = false;
        IDbConnection conn = CartDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "update shoppingcart set Title=@title, UnitPrice=@unitPrice, Quantity=@quantity where CustomerId=@id";
        cmd.Connection = conn;
        cmd.CommandText = query;

        cmd.Parameters.Add(new MySqlParameter("@id", item.CustomerId));
        cmd.Parameters.Add(new MySqlParameter("@title", item.product.ProductName));
        cmd.Parameters.Add(new MySqlParameter("@unitPrice", item.product.UnitPrice));
        cmd.Parameters.Add(new MySqlParameter("@quantity", item.product.Quantity));


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