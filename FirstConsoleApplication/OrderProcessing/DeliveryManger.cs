using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class DeliveryManger:Manager
    {
        List<Order> orderData = new List<Order>();
        
        public void insert(Order order)
        {
            orderData.Add(order);
        }
       
        public void update(Order order)
        {
            orderData.Remove(order);
            orderData.Add(order);

            Console.WriteLine("ordere data updates");
        }
        public void delete(Order order)
        {
            orderData.Remove(order);
        }

        public List<Order> getAll()
        {
            return orderData;
        }

        public Order getOrderById(int id)
        {
            return new Order { OrderId = id };
        }
        
        public Order getOrderByVendor(string vendor)
        {
            return new WorkOrder { Vendor=vendor};
        }
        */
    }
}
