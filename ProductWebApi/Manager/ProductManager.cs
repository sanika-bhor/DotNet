using ProductWebApi.Model;

namespace ProductWebApi.Manager
{
    public class ProductManager : IProductManager
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
            using(var context=new CollectionContext())
            {
                var product =from p in context.Product select p;
                return product as List<Product>;

            }
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