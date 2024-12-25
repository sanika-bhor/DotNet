using System.Collections.Generic;

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
          foreach(Order singleOrder in orderData)
            {
                if(singleOrder.OrderId==order.OrderId)
                {
                    orderData.Add(singleOrder);
                }
            }
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
            foreach(Order singleOrder in orderData)
            {
                if (singleOrder.OrderId == id)
                    return singleOrder;
            }
            return null;
        }
        
        public List<Order> getOrderByVendor(string vendor)
        {
            List<Order> orderList = new List<Order>();
            foreach(WorkOrder singleOrder in orderData)
            {
                 if(singleOrder.Vendor==vendor)
                {
                    orderList.Add(singleOrder);
                }
            }
            return orderList;

        }
        
    }
}
