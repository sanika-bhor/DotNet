using ProductWebApi.Model;

namespace ProductWebApi.Repository
{
    public interface IProductRepo
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(int id);
    }
}