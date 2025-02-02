using paymentProcessingDemo.Manager;
using paymentProcessingDemo.Models;
using paymentProcessingDemo.Repository.Interface;

namespace paymentProcessingDemo.Repository
{
    public class PaymentRepo : IPaymentRepo
    {
        public bool Delete(int id)
        {
            PaymentManager pm = new PaymentManager();
            bool paymentStatus = pm.Delete(id);
            return paymentStatus;
        }

        public List<Payment> GetAllPayment()
        {
            PaymentManager pm=new PaymentManager();
            List<Payment> payments=pm.GetAllPayment();
            return payments;
        }

        public Payment GetElementById(int id)
        {
            PaymentManager pm = new PaymentManager();
            Payment payments = pm.GetElementById(id);
            return payments;
        }

        public bool Insert(Payment payment)
        {
            PaymentManager pm = new PaymentManager();
            bool paymentStatus = pm.Insert(payment);
            return paymentStatus;
        }

        public bool Update(Payment payment)
        {
            PaymentManager pm = new PaymentManager();
            bool paymentStatus = pm.Update(payment);
            return paymentStatus;
        }
    }
}