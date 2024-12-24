using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class WorkOrderService:IOrderService
    {
        DeliveryManger deliveryManger = new DeliveryManger();
        public void Cancel(Order order)
        {
            deliveryManger.delete(order);
        }
        public void create(Order order)
        {
            deliveryManger.insert(order);
        }

        public void getOrder(int id)
        {
            deliveryManger.getOrderById(id);
        }

        public void update(Order order)
        {
            deliveryManger.update(order);
        }
        public List<Order> getAllOrders()
        {
            List<Order> order = deliveryManger.getAll();
            return order;
        }

        public bool process(Order order)
        {
            bool status = true;
            return status; ;
        }
    }
}
