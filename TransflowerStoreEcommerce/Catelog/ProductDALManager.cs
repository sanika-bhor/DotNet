using System.Data;
using System.Data.SqlTypes;
using Catelog;
using MySql.Data.MySqlClient;

namespace DAL;
public class ProductDALManager
{
    // public static IDbConnection getConnection()
    // {
    //     IDbConnection conn=new MySqlConnection(@"server = localhost; port = 3306; user = root; password = root123; database = ecommerce");
    //     return conn;
    // }
    // public static List<Product> GetAllProducts()
    // {
    //     List<Product>   products=new List<Product>();
    //     IDbConnection conn = ProductDALManager.getConnection();
    //     IDbCommand cmd=new MySqlCommand();
    //     string query="select * from product";
    //     cmd.CommandText=query;
    //     cmd.Connection=conn;
    //     IDataReader reader=null;
    //     try
    //     {
    //         conn.Open();
    //         reader=cmd.ExecuteReader();
    //         while (reader.Read())
    //         {
    //             int id=int.Parse(reader["ProductId"].ToString());
    //             string name=reader["Title"].ToString();
    //             string description=reader["Description"].ToString();
    //             int unitPrice = int.Parse(reader["UnitPrice"].ToString());
    //             int quantity = int.Parse(reader["Quantity"].ToString());
    //             string image = reader["Image"].ToString();

    //             Product product=new Product{
    //                 ProductId=id,
    //                 ProductName=name,
    //                 Description=description,
    //                 UnitPrice=unitPrice,
    //                 Quantity=quantity,
    //                 Image=image
    //             };

    //             products.Add(product);
    //         }

    //     }
    //     catch(MySqlException exp)
    //     {
    //         string msg=exp.Message;
    //         Console.WriteLine(msg);
    //     }
    //     finally
    //     {
    //         if(conn.State==ConnectionState.Open)
    //         {
    //             conn.Close();
    //         }
    //     }
    //     return products;
    // }

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
        // IDbConnection conn = ProductDALManager.dbConnection();
        IDbConnection conn = new MySqlConnection();
        conn.ConnectionString = @"server=localhost;port=3306;user=root;password=root123;database=ecommerce";

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


                Product product = new Product(id, title, description, quntity, unitPrice,image);

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

}