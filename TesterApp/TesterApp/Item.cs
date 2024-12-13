using Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog;

namespace ShoppingCart
{
    public class Item
    {
        public int quantity;
        Product product=new Product();

        public Item(Product product, int quntity)
        {
            this.product = product;
            this.quantity = quntity;
        }

    }
}
