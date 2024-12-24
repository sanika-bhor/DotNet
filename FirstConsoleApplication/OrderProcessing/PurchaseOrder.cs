using System;
using System.Collections.Generic;
using CRM;
using ShoppingCart;

namespace OrderProcessing
{
    public class PurchaseOrder
    {
        public int PurchaseOrder_id { get; set; }
        public DateTime OrderTime { get; set; }
        public Customer TheCustomer { get; set; }
        public List<Item> Items = new List<Item>();
    }
}
