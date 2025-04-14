using Catalog;

namespace Repository.ProductRepository.Interface
{
    public interface IProductRepository
    {
        bool insert(Product product);
        bool update(Product product);
        bool delete(Product product);
        List<Product> getAll();
    }
}