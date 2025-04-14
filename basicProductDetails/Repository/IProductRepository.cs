using Catalog;

namespace Repository.ProductRepository.Interface
{
    public interface IProductRepository
    {
        void insert(Product product);
        void update(Product product);
        void delete(int id);
        void getAll();
    }
}