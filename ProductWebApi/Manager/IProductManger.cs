using ProductWebApi.Model;

namespace ProductWebApi.Manager
{
    public interface IProductManager
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int id);
    }
}