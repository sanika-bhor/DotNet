using Model.Catalog;
using Repositories.ProductRepository.Interface;

namespace Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> products = new List<Product>();
        public bool delete(int id)
        {
            bool status = false;
            if (id != null)
            {
                Product p = products.Find(p => p.getId() == id);
                if (p != null)
                {
                    products.Remove(p);
                }
            }
            return status;
        }

        public List<Product> getAll()
        {
            return products;
        }

        public bool insert(Product product)
        {
            bool status = false;
            if (product != null)
            {

                products.Add(product);
                status = true;
            }

            return status;
        }

        public bool update(Product product)
        {
            bool status = false;
            if (product != null)
            {
                int id = product.getId();
                Product p = products.Find(p => p.getId() == id);
                if (p != null)
                {
                    p.setTitle(product.getTitle());
                    p.setDescription(product.getDescription());
                    p.setPrice(product.getPice());
                    p.setQuantity(product.getQuantity());
                    status = true;
                }
            }
            return status;
        }

       public Product GetProductById(int id)
        {
            if (id != null)
            {
                Product p = products.Find(p => p.getId() == id);
                if (p != null)
                {
                   return p;
                }
            }
            return null;
        }

        public Product GetProductByTitle(string title)
        {
            if (title != null)
            {
                Product p = products.Find(p => p.getTitle() == title);
                if (p != null)
                {
                    return p;
                }
            }
            return null;
        }

    }
}
