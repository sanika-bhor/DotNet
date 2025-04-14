using Services.ProductService.Interface;
namespace Services.ProductService
{
    public interface IProductService:IProductService
    {
          void insert(Product product)
          {
            using(ProductRepository repo=new ProductRepository())
            {
                bool status=repo.insert(product);
                if(status==true)
                {
                    Console.WriteLine("Product inserted successfully...");
                }
                else
                {
                    Console.WriteLine("Failed to insert product");
                }
            }
          }
        void update(Product product)
        {
             using(ProductRepository repo=new ProductRepository())
            {
                bool status=repo.update(product);
                if(status==true)
                {
                    Console.WriteLine("Product updated successfully...");
                }
                else
                {
                    Console.WriteLine("Failed to update product");
                }
            }
        }
        bool delete(int id)
        {
            using(ProductRepository repo=new ProductRepository())
            {
                bool status=repo.delete(id);
                if(status==true)
                {
                    Console.WriteLine("Product deleted successfully...");
                }
                else
                {
                    Console.WriteLine("Failed to delete product");
                }
            }
        }
        void getAll(){
            using(ProductRepository repo=new ProductRepository())
            {
                List<Product> allProducts = repo.getAll();
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
    
}