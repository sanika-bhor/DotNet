using Model.Catalog;

namespace Helper.ProductIoOperation.Interface
{
    public interface IProductIOManager
    {
        // Save products to a file
        public void saveProductsToFile(string filename, List<Product> products);

        // Load products from a file
        public List<Product> loadProductsFromFile(string filename);
        // Display products in the console
        public void displayProducts(List<Product> products);

        public void addProduct(List<Product> products, Product product);
        public void removeProduct(List<Product> products, int productId);
        public void updateProduct(List<Product> products, Product updatedProduct);
    }
}