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
}