using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class PurchaseOrderService : IOrderService
    {
        PurchaseManager purchaseManager = new PurchaseManager();
        public void Cancel(Order order)
        {
            purchaseManager.delete(order);
        }
        public void create(Order order)
        {
            purchaseManager.insert(order);
        }

        public Order getOrder(int id)
        {
           Order o= purchaseManager.getOrderById(id);
            return o;

        }

        public void update(Order order)
        {
            purchaseManager.update(order);
        }
        public List<Order> getAllOrders()
        {
            List<Order>order= purchaseManager.getAll();
            return order;
        }

        public bool process(Order order)
        {
            bool status = true;
            return status; ;
        }
    }
}
