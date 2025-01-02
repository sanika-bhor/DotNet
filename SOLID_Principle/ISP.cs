// ISP(Interface segragation principle)
namespace ISP
{
    public interface IOrder
    {
        public void AddToCart();
    }

    public interface IOnlineOrder
    {
        public void PayOnline();
    }

    public class OnlineOrder:IOrder,IOnlineOrder
    {
        public void AddToCart()
        {
            Console.WriteLine("items added to the cart please pay online before order deliever ..");
        }
        public void PayOnline()
        {
            Console.WriteLine("pay online with diiferent payment methods....");
        }
    }
    public class OflineOrder:IOrder
    {
         public void AddToCart()
        {
            Console.WriteLine("items added to the cart please pay at the time of order deliever..");
        }
    }
}