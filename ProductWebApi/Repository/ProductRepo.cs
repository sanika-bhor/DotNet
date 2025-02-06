using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductWebApi.Manager;
using ProductWebApi.Model;

namespace ProductWebApi.Repository
{
    public class ProductRepo : IProductRepo
    {
        public bool Delete(int id)
        {
            ProductManager pm = new ProductManager();
            bool status = pm.Delete(id);
            return status;
        }

        public Product GetProductById(int id)
        {
            ProductManager pm = new ProductManager();
            Product p=pm.GetProductById(id);
            return p;
        }

        public List<Product> GetProducts()
        {
            ProductManager pm=new ProductManager();
            List<Product> products=pm.GetProducts();
            return products;
        }

        public bool Insert(Product product)
        {
            ProductManager pm = new ProductManager();
            bool status=pm.Insert(product);
            return status;
        }

        public bool Update(Product product)
        {
            ProductManager pm = new ProductManager();
            bool status = pm.Update(product);
            return status;
        }
    }
}