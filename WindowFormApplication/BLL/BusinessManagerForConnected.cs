using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog;
using DAL;

namespace BLL
{
    public static class BusinessManagerForConnected
    {
       
        
        public static List<Product> getAllProducts()
        {
            List<Product> allProducts = new List<Product>();
            #region harcoded way
            Product Rose = new Product(101, "rose", "valentine flower", 4523, 20);
            Product Aster = new Product(101, "aster", "festival flower", 563210, 5);
            Product Gerbera = new Product(101, "gerberaa", "merrage flower", 0, 30);
            Product Lotus = new Product(101, "rose", "unique flower", 562, 50);


            allProducts.Add(Rose);
            allProducts.Add(Aster);
            allProducts.Add(Gerbera);
            allProducts.Add(Lotus);
            #endregion

            return allProducts;
        }

        public static IEnumerable<Product> getSoldProducts()
        {
            List<Product> allProduct = BusinessManagerForConnected.getAllProducts();
            IEnumerable<Product> soldProducts= (IEnumerable<Product>) from product in allProduct
                                        where product.Quantity==0
                                        select product;
            return soldProducts;
        }

        //using ADO.net
        public static List<Product> getAllDbProducts()
        {
            ICatelogDbManager manager =new CatelogDbConnectedManager();

            List<Product> allProducts = (List<Product>)manager.getAllProductFromDB();
            return allProducts;
        }

        public static List<Product> getSoldProductsFromDb()
        {
            ICatelogDbManager manager = new CatelogDbConnectedManager();
            List<Product> soldProduct = manager.getSoldProductsFromDb();
            return soldProduct;
        }

        public static bool insertProductInDb(Product p)
        {
            bool status = false;
            ICatelogDbManager manager = new CatelogDbConnectedManager();
            status = manager.insertProduct(p);
            return status;
        }

        public static bool deleteFromProduct(int id)
        {
            bool status = false;
            ICatelogDbManager manager = new CatelogDbConnectedManager();
            status = manager.deleteProduct(id);
            return status;
        }

        public static Product getProductById(int id)
        {
            ICatelogDbManager manager = new CatelogDbConnectedManager();
            Product product = manager.getProductById(id);
            return product;
        }

        public static bool UpdateProductById(Product p)
        {
            bool status = false;
            ICatelogDbManager manager = new CatelogDbConnectedManager();
            status = manager.UpdateProduct(p);
            return status;
        }
    }
}
