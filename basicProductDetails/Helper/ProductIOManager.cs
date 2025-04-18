using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using Model.Catalog;
using System.Text.Json;
using Helper.ProductIoOperation.Interface;

namespace Helper.ProductIoOperation
{
    public class ProductIOManager:IProductIOManager
    {
        public List<Product> products=new List<Product>();
    // Save products to a file
    public  void saveProductsToFile(string filename, List<Product> p)
    {
       FileStream fst=new FileStream(filename,FileMode.OpenOrCreate);
       JsonSerializer.Serialize(fst,p);
       Console.WriteLine("data serialize and saved");
       fst.Close();
    }

    // Load products from a file
    public List<Product> loadProductsFromFile(string filename)
    {
            FileStream fst = new FileStream(filename, FileMode.Open);
            products = JsonSerializer.Deserialize<List<Product>>(fst);
            Console.WriteLine("Data deserialized from file.");
            fst.Close();
            return products;
 
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