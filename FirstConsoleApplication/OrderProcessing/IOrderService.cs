using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    interface IOrderService
    {
         void Cancel(Order order);
         void create(Order order);
         void getOrder(int id);
         void update(Order order);
         List<Order> getAllOrders();
         bool process(Order order);
    }
}
