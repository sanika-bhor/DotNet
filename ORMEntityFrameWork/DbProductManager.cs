using System.Linq;
using System.Net;
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

        public Product GetById(int id)
        {
            using (var context = new CollectionContext())
            {
                var product = context.Product.Find(id);
                return product;
            }
        }

        public bool Insert(Product product)
        {
            bool status;
            using(var context=new CollectionContext())
            {
                context.Product.Add(product);
                context.SaveChanges();
                status=true;
            }
            return status;
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }



        public bool Update(Product product)
        {
            bool status=false;
            using(var context=new CollectionContext())
            {
                var updatingProduct=context.Product.Find(product.ProductId);
                updatingProduct.Title=product.Title;
                updatingProduct.Description=product.Description;
                updatingProduct.Unitprice=product.Unitprice;
                updatingProduct.Quantity=product.Quantity;
                context.SaveChanges();
                status = true;
            }
            return status;
        }

        
    }
}