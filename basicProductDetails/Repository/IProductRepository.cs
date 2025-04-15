using Model.Catalog;

namespace Repository.ProductRepository.Interface
{
    public interface IProductRepository
    {
        bool insert(Product product);
        bool update(Product product);
        bool delete(int id);
        List<Product> getAll();
        
        Product GetProductById(int id);

        Product GetProductByTitle(string title);
    }
}