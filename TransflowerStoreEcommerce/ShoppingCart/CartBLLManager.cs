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
}