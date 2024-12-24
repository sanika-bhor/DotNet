using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class PurchaseManager
    {
        public List<Order> Orders { get; set; }

        public void insert(Order order)
        {
            Orders.Add(order);
        }

        public void update(Order order)
        { 
            foreach(Order singleOrder in Orders)
            {
                if(singleOrder.OrderId==order.OrderId)
                {
                    Orders.Add(singleOrder);
                }
            }
        }

        public void delete(Order order)
        {
            Orders.Remove(order);
        }

        public List<Order> getAll()
        {
            return Orders;
        }

        public Order getOrderById(int id)
        {
            foreach(Order singleOrder in Orders)
            {
                if(singleOrder.OrderId==id)
                {
                    return singleOrder;
                }
            }
            return null;
        }

        /*public List<Order> getCustomerById(string customerId)
        {
            List<Order> order = new List<Order>();

            foreach (PurchaseOrder singleOrder in this.order)
            {
                if (singleOrder.TheCustomer.LoginId == customerId)
                {
                    return order;
                }
            }

            return null;
        }*/
    }
}
