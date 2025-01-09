using ShoppingCart;
using DAL;

namespace BLL;

public class CartBLLManager
{
    public static List<Item> getAllItems()
    {
        List<Item> allItems = (List<Item>)CartDALManager.getAllItemsFromDB();
        return allItems;

    }

     public static Item getItemById(int id)
    {
        Item item=CartDALManager.getItemById(id);
        return item;
    }

    public static bool insertCart(Item item)
    {
        return CartDALManager.insertCart(item);
    }

    public static bool deleteItemById(int id)
    {
        bool status = CartDALManager.deleteItemById(id);
        return status;
    }

    public static bool updateItem(Item item)
    {
        return CartDALManager.UpdateItem(item);
    }
}