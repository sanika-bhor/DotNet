using Catalog;
using Repository.ProductRepository.Interface;

namespace Repository.ProductRepository
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
    }
}
