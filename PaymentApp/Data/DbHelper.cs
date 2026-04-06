using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace PaymentAppADO.Data
{
    public class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void SavePayment(string orderId, string paymentId, string status, decimal amount)
        {
            using (MySqlConnection con = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO Payments (OrderId, PaymentId, Status, Amount) VALUES (@OrderId, @PaymentId, @Status, @Amount)";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                cmd.Parameters.AddWithValue("@PaymentId", paymentId);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Amount", amount);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}