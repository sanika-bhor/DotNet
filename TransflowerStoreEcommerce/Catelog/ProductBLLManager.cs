using Catelog;
using DAL;

namespace BLL;

public class ProductBLLManager
{
    public static List<Product> getAllProducts()
    {
        Console.WriteLine("staring in bll");
        List<Product> allProducts= (List<Product>)ProductDALManager.getAllProductFromDB();
        Console.WriteLine("getting product");

        return allProducts;

    }
    public static Product getProductByID(int id)
    {
        Product product=ProductDALManager.getProductById(id);
        return product;
    }

    public static bool deleteProductById(int id)
    {
        bool status=ProductDALManager.deleteProductById(id);
        return status;
    }

    public static bool insertProduct(Product p)
    {
        return ProductDALManager.insertProduct(p);
    }

    public static bool updateProduct(Product p)
    {
        return ProductDALManager.UpdateProduct(p);
    }
}