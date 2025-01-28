using ORMEntityFramework;

namespace DbProductManager
{
    public class DbProductManager
    {
        List<Product> GetAll()
        {
            using(var context=new CollectionContext())
            {
                var products=context.Products;
                return products.ToList<Product>();

            }
        }
    }
}