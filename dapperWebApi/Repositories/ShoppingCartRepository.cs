using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace EcommerceDapper
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        string connectionString = "Server=localhost;Database=tflshoppingecommercedemo;User ID=root;Password=password;";
        public bool AddToCart(int userid, int productid, int quantity, string imgUrl)
        {
            bool status = false;
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.QueryFirstOrDefault("AddToCart", new { uid = userid, pid = productid, stock = quantity,img=imgUrl }, commandType: CommandType.StoredProcedure);
                    status = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }

            return status;
        }

        public bool RemoveFromCart(int userid, int productid,int quantity)
        {
            bool status=false;
            try
            {
                 using(var connection = new MySqlConnection(connectionString))
                {
                    connection.QueryFirstOrDefault("RemoveFromCart",new {uid=userid,pid=productid,p_quantity= quantity },commandType: CommandType.StoredProcedure);
                    status=true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status=false;
            }
            return status;
        }
    }
}