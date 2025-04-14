namespace Services.ProductService.Interface
{
    public interface IProductService
    {
          bool insert(Product product);
        bool update(Product product);
        bool delete(int id);
        List<Product> getAll();
    }
    
}