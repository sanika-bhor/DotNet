
namespace Services.ProductService.Interface
{
    public interface IProductService
    {

        public void applyDiscount(int productId, double discount);

        void calculateTotalPrice(int productId);

        //     void searchProductByTitle(string title) {
        // 			Product product = repo.findProductByTitle(title);
        // 			if (product) {
        // 				product->display();
        // }

        //             else
        // {
        //     std::cout << "Product not found!" << std::endl;
        // }
        // 		}
    }

}