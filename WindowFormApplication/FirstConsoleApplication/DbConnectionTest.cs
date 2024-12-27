using System;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
namespace FirstConsoleApplication
{
    public class DbConnectionTest
    {
        public static void Main(string[] args)
        {
            IDbConnection conn = new MySqlConnection(@"Data Source=localhost;Initial Catalog=ECommerce;User ID=root;Password=root123");
            IDbCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("connection establish successfully");
                }
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
        }
    }
}
