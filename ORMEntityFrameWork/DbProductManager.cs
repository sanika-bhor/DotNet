using System.Linq;
namespace ORMEntityFramework
{
    public class DbProductManager:IDbManager
    {
        public List<Product> GetAll()
        {
            using (var context = new CollectionContext())
            {
                var products = from prod in context.Product select prod;
                return products.ToList<Product>();
            }

        }
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            using(var context=new CollectionContext())
            {
                var product=context.Product.Find(id);
                return product;
            }
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        
    }
}