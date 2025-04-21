using Repositories.ProductRepository;
using Services.ProductService;
using Repositories.ProductRepository.Interface;
using Model.Catalog;
using Services.ProductService.Interface;
namespace Controller.ProductController
{
    public class ProductController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        // private readonly ProductIOManager _productIOManager;

        public ProductController(ProductRepository repo, ProductService srv)
        {
            _productRepository = repo;
            _productService = srv;
        }

    //  public ProductController(ProductRepository repo, ProductService srv,ProductIOManager pm)
    //     {
    //         _productRepository = repo;
    //         _productService = srv;
    //         _productIOManager=pm;
    //     }
        public void insert(Product product)
        {
            bool status = _productRepository.insert(product);
            if (status == true)
            {
                Console.WriteLine("Product inserted successfully...");
            }
            else
            {
                Console.WriteLine("Failed to insert product");
            }
        }
        public void update(Product product)
        {
            bool status = _productRepository.update(product);
            if (status == true)
            {
                Console.WriteLine("Product updated successfully...");
            }
            else
            {
                Console.WriteLine("Failed to update product");
            }
        }
        public void delete(int id)
        {

            bool status = _productRepository.delete(id);
            if (status == true)
            {
                Console.WriteLine("Product deleted successfully...");
            }
            else
            {
                Console.WriteLine("Failed to delete product");
            }

        }
        public List<Product> getAll()
        {

            List<Product> allProducts = _productRepository.getAll();
            if (allProducts != null)
            {
                return allProducts;
            }
            return null;
        }
    }

}