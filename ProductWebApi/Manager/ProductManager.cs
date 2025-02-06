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
                return product.ToList();

            }
        }

        public bool Insert(Product product)
        {
            bool status=false;
            using(var context=new CollectionContext())
            {
                context.Product.Add(product);
                context.SaveChanges();
                status=true;
            }
            return status;
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}