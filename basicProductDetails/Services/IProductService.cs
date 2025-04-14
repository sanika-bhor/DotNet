using Model.Catalog;
namespace Services.ProductService.Interface
{
    public interface IProductService
    {
        void insert(Product product);
        void update(Product product);
        void delete(int id);
        void getAll();
    }
    
}