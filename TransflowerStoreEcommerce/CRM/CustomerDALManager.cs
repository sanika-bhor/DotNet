using System.Data;
using System.Data.SqlTypes;
using CRM;
using MySql.Data.MySqlClient;

namespace DAL;
public class CustomerDALManager
{
    public static IDbConnection dbConnection()
    {
        IDbConnection conn = new MySqlConnection();
        conn.ConnectionString = @"server=localhost;port=3306;user=root;password=root123;database=ecommerce";
        return conn;
    }

    public static List<Customer> getAllProductFromDB()
    {
        List<Customer> customers = new List<Customer>();
        IDbConnection conn = CustomerDALManager.dbConnection();
        IDbCommand cmd = new MySqlCommand();
        string query = "select * from Customer";
        cmd.CommandText = query;
        cmd.Connection = conn;

        IDataReader reader = null;


        try
        {
            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = int.Parse(reader["CustomerId"].ToString());
                string loginId = reader["LoginId"].ToString();
                string password = reader["Password"].ToString();
                string name = reader["CustomerName"].ToString();
                string email = reader["Email"].ToString();
                string contactNo = reader["ContactNo"].ToString();
                string location = reader["Location"].ToString();


                Customer customer = new Customer
                {
                    CustomerId=id,
                    LoginId=loginId,
                    Password=password,
                    CustomerName=name,
                    Email=email,
                    ContactNo=contactNo,
                    Location=location
                };

                customers.Add(customer);
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

        return customers;
    }

}