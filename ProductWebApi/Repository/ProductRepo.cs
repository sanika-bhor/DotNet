using ProductWebApi.Manager;
using ProductWebApi.Model;

namespace ProductWebApi.Repository
{
    public class ProductRepo : IProductRepo
    {
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
            ProductManager pm=new ProductManager();
            List<Product> products=pm.GetProducts();
            return products;
        }

        public bool Insert(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}