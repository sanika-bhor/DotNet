using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog;

namespace BLL
{
    public static class BusinessManager
    {
        public static List<Product> getAllProducts()
        {
            List<Product> allProducts = new List<Product>();

            Product Rose = new Product(101, "rose", "valentine flower", 4523, 20);
            Product Aster = new Product(101, "aster", "festival flower", 563210, 5);
            Product Gerbera = new Product(101, "gerberaa", "merrage flower", 7423, 30);
            Product Lotus = new Product(101, "rose", "unique flower", 562, 50);

            allProducts.Add(Rose);
            allProducts.Add(Aster);
            allProducts.Add(Gerbera);
            allProducts.Add(Lotus);

            return allProducts;
        }
    }
}
