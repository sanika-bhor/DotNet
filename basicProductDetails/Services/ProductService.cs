using Services.ProductService.Interface;
using Repository.ProductRepository;
using Repository.ProductRepository.Interface;
using Model.Catalog;
namespace Services.ProductService
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository=new ProductRepository();

        public  void insert(Product product)
          {
                bool status=_productRepository.insert(product);
                if(status==true)
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
                bool status=_productRepository.update(product);
                if(status==true)
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
           
                bool status=_productRepository.delete(id);
                if(status==true)
                {
                    Console.WriteLine("Product deleted successfully...");
                }
                else
                {
                    Console.WriteLine("Failed to delete product");
                }
            
        }
        public void getAll(){
           
                List<Product> allProducts = _productRepository.getAll();
            if (allProducts != null)
            {
                foreach (Product p in allProducts)
                {
                    p.display();
                    Console.WriteLine("------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("no product available");
            }
            
        }
    }
    
}