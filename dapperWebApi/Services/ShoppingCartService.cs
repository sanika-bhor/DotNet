using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace EcommerceDapper
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public bool AddToCart(int userid, int productid, int quantity, string imgUrl)
        {
           bool status= _shoppingCartRepository.AddToCart(userid, productid, quantity,imgUrl);
           return status;
        }

        public bool RemoveFromCart(int userid, int productid,int quantity)
        {
            bool status = _shoppingCartRepository.RemoveFromCart(userid, productid, quantity);
            return status;
        }
    }
}