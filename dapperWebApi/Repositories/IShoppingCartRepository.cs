
namespace EcommerceDapper
{
    public interface IShoppingCartRepository
    {
        public bool AddToCart(int userid,int productid,int quantity, string imgUrl);

        public bool RemoveFromCart(int userid,int productid,int quantity);
    }
}