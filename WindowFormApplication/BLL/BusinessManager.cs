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
            List<Product> allProducts = CatelogDbManager.getAllProductFromDB();

/*            Product Rose = new Product(101, "rose", "valentine flower", 4523, 20);
            Product Aster = new Product(101, "aster", "festival flower", 563210, 5);
            Product Gerbera = new Product(101, "gerberaa", "merrage flower", 0, 30);
            Product Lotus = new Product(101, "rose", "unique flower", 562, 50);

            allProducts.Add(Rose);
            allProducts.Add(Aster);
            allProducts.Add(Gerbera);
            allProducts.Add(Lotus);*/

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


       
    }
}
