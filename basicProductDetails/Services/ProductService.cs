using Model.Catalog;
using Repository.ProductRepository;
using Services.ProductService.Interface;
namespace Services.ProductService
{
    public class ProductService : IProductService
    {
        public ProductRepository repo; // Reference to the ProductRepository

        public ProductService(ProductRepository r)
        {
            this.repo = r;
        }

        public void applyDiscount(int productId, double discount)
        {
            Product product = repo.GetProductById(productId);
            if (product != null)
            {
                double discountedPrice = product.getDiscountedPrice(discount);
                product.setPrice(discountedPrice);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }


        public void calculateTotalPrice(int productId)
        {
            Product product = repo.GetProductById(productId);
            if (product != null)
            {
                double totalPrice = product.getTotalPrice();
                Console.WriteLine("Total Price for " + product.getTitle() + ": $" + totalPrice);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        void IProductService.calculateTotalPrice(int productId)
        {
            calculateTotalPrice(productId);
        }

        public void searchProductByTitle(string title)
        {
            Product product = repo.GetProductByTitle(title);
            if (product != null)
            {
                product.display();
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
    }

}