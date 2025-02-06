using ProductWebApi.Model;
using ProductWebApi.Repository;

namespace ProductWebApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo repo)
        {
            this._productRepo=repo;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
           List<Product> products=_productRepo.GetProducts();
           return products;
        }

        public bool Insert(Product product)
        {
            bool status = _productRepo.Insert(product);
            return status;
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}