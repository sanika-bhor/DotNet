using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
     public interface IOrderService
    {
        public void Cancel(Order order);
        public void create(Order order);
        public void getOrder(int id);
        public void update(Order order);
        public List<Order> getAllOrders();
        public bool process(Order order);
    }
}
