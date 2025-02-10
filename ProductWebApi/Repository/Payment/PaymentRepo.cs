using ProductWebApi.Manager;
using ProductWebApi.Model;

namespace ProductWebApi.Repository
{
    public class PaymentRepo : IPaymentRepo
    {
        public bool Delete(int id)
        {
            PaymentManager pm = new PaymentManager();
            bool status=pm.Delete(id);
            return status;
        }

        public Payment GetPaymentById(int id)
        {
           PaymentManager pm=new PaymentManager();
           Payment payment=pm.GetPaymentById(id);
           return payment;
        }

        public List<Payment> GetPayments()
        {
           PaymentManager pm=new PaymentManager();
           List<Payment> payments=pm.GetPayments();
           return payments;
        }

        public bool Insert(Payment payment)
        {
            PaymentManager pm = new PaymentManager();
            bool status=pm.Insert(payment);
            return status;
        }

        public bool Update(Payment payment)
        {
            PaymentManager pm = new PaymentManager();
            bool status=pm.Update(payment);
            return status;
        }
    }
}