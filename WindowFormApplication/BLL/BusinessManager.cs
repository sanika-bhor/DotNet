using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog;
using DAL;

namespace BLL
{
    public static class BusinessManager
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
            List<Product> allProduct = BusinessManager.getAllProducts();
            IEnumerable<Product> soldProducts= (IEnumerable<Product>) from product in allProduct
                                        where product.Quantity==0
                                        select product;
            return soldProducts;
        }

        //using ADO.net
        public static List<Product> getAllDbProducts()
        {
            List<Product> allProducts = (List<Product>)CatelogDbManager.getAllProductFromDB();
            return allProducts;
        }

        public static List<Product> getSoldProductsFromDb()
        {
            List<Product> soldProduct = CatelogDbManager.getSoldProductsFromDb();
            return soldProduct;
        }

        public static bool insertProductInDb(Product p)
        {
            bool status = false;

            status = CatelogDbManager.insertProduct(p);
            return status;
        }

        public static bool deleteFromProduct(int id)
        {
            bool status = false;
            status=CatelogDbManager.deleteProduct(id);
            return status;
        }
    }
}
