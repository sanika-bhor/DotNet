using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using Model.Catalog;
using System.Text.Json;

namespace Helper.ProductIoOperation
{
    public class ProductIOManager
    {
        public List<Product> products=new List<Product>();
    // Save products to a file
    public void saveProductsToFile(string filename, List<Product> products)
    {
        // Open the file in write mode
        // std::ofstream file(filename);
        // if (!file.is_open())
        // {
        //     std::cerr << "Error opening file for writing: " << filename << std::endl;
        //     return;
        // }
        // // Write the products to the file
        // for (const auto&product : products) {
        //     file << product.getProductId() << ","
        //         << product.getTitle() << ","
        //         << product.getDescription() << ","
        //         << product.getPrice() << ","
        //         << product.getQuantity() << "\n";
        // }
        // // Close the file
        // file.close();
        // std::cout << "Products saved to file: " << filename << std::endl;
    }

    // Load products from a file
    public List<Product> loadProductsFromFile(string filename)
    {
        // std::vector<Product> products;
        // // Open the file in read mode
        // std::ifstream file(filename);
        // if (!file.is_open())
        // {
        //     std::cerr << "Error opening file for reading: " << filename << std::endl;
        //     return products;
        // }
        // // Read the products from the file
        // std::string line;
        // while (std::getline(file, line))
        // {
        //     std::istringstream iss(line);
        //     int id, quantity;
        //     std::string title, description;
        //     double price;
        //     if (iss >> id && iss.ignore() && std::getline(iss, title, ',') &&
        //         std::getline(iss, description, ',') &&
        //         iss >> price && iss.ignore() &&
        //         iss >> quantity)
        //     {
        //         Product product(id, title, description, price, quantity);
        //         products.push_back(product);
        //     }
        return null;
        
        // Close the fil
    }

    // Display products in the console
   public void displayProducts(List<Product> products)
    {
        Console.WriteLine("Product List:" );
        foreach (Product p in products) {
            p.display();
        }
    }

   public void addProduct(List<Product> products,  Product product)
    {
        products.Add(product);
        Console.WriteLine("Product added: " + product.getTitle());
    }
   public void removeProduct(List<Product>products, int productId)
    {
        Product p=products.Find(p=>p.getId()==productId);
        if (p != null)
        {
            products.Remove(p);
                Console.WriteLine("Product with ID " + productId+ " not found." );
            }
            else
            {
                Console.WriteLine("Product removed: " + p.getTitle());

            }
    }
   public void updateProduct(List<Product> products,  Product updatedProduct)
    {


            Product p = products.Find(p => p.getId() == updatedProduct.getId());
            if (p != null)
            {
                p.setTitle(updatedProduct.getTitle());
                p.setDescription(updatedProduct.getDescription());
                p.setPrice(updatedProduct.getPice());
                p.setQuantity(updatedProduct.getQuantity());
                Console.WriteLine("Product updated: " + updatedProduct.getTitle());
            }
            else
            {
                Console.WriteLine(" Product with ID " +updatedProduct.getId() + " not found.");
            }
    }
}
}