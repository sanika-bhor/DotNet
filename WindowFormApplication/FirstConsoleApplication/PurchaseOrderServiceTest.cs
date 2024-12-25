using System;
using System.Collections.Generic;
using Catalog;
using CRM;
using OrderProcessing;
using ShoppingCart;

namespace FirstConsoleApplication
{
    public class PurchaseOrderServiceTest
    {
        static void Main(string[] args)
        {
            PurchaseOrderService orderService = new PurchaseOrderService();
            Customer theCustomer = new Customer
            { 
                LoginId="1001",
                Password="sanika", 
                Name="sanika", 
                Email="bhorsanika0239@gmail.com", 
                ContactNo="8446756339", 
                Location="Manchar"
            };

            Product product1 = new Product(1, "Rose", "valentine flower", 20, 5);
            Product product2 = new Product(2, "Mobile", "Samsung mobile", 3, 22000);
            Product product3 = new Product(3, "Laptop", "Lenova Laptop", 2, 100000);

            List<Item> itemList = new List<Item>();
            Item item1 = new Item(product1, 5);
            Item item2 = new Item(product2, 3);
            Item item3 = new Item(product3, 2);

            itemList.Add(item1);
            itemList.Add(item2);
            itemList.Add(item3);


            List<Order> orderList = new List<Order>();
            DateTime orderTime = DateTime.Now;

            Order order1 = new PurchaseOrder
            {
                OrderId = 101, 
                OrderTime=orderTime,
                TheCustomer= theCustomer,
                Items= itemList
            };

            Order order2 = new PurchaseOrder
            {
                OrderId  = 102,
                OrderTime = orderTime,
                TheCustomer = theCustomer,
                Items = itemList
            };

            //create order
            orderService.create(order1);
            orderService.create(order2);

            //all orders
            List<Order> allOrder = orderService.getAllOrders();
            Console.WriteLine("order Count:" +allOrder.Count);

            //order by id
            Order o=orderService.getOrder(102);
            Console.WriteLine(o.OrderId+"  "+o.OrderTime);
            
            //order cancle
            orderService.Cancel(order2 );

            //new order count
            List<Order> newOrderList = orderService.getAllOrders();
            Console.WriteLine("after canceling order new order Count:" + newOrderList.Count);

        }
    }
}
