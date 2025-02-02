using paymentProcessingDemo.Manager.Interface;
using paymentProcessingDemo.Models;

namespace paymentProcessingDemo.Manager
{
    public class PaymentManager : IPaymentManager
    {
        public bool Delete(int id)
        {
            bool status=false;
            using (var context = new CollectionContext())
            {
               context.Payments.Remove(context.Payments.Find(id));
               context.SaveChanges();
               status=true;
            }
            return status;
        }

        public List<Payment> GetAllPayment()
        {
            using(var context =new CollectionContext())
            {
                var payment=from p in context.Payments select p;
                return payment.ToList<Payment>();
            }
        }

        public Payment GetElementById(int id)
        {
            using (var context=new CollectionContext())
            {
                var payment=context.Payments.Find(id);
                return payment;
            }
        }

        public bool Insert(Payment payment)
        {
            bool status=false;
            using(var context =new CollectionContext())
            {
                context.Payments.Add(payment);
                context.SaveChanges();
                status=true;

            }
            return status;
        }

        public bool Update(Payment payment)
        {
            bool status = false;
            using (var context = new CollectionContext())
            {
                var paymentData=context.Payments.Find(payment.Id);
               paymentData.OrderId=payment.OrderId;
               paymentData.Amount=payment.Amount;
               paymentData.PaymentDate=payment.PaymentDate;
               paymentData.PaymentMode=payment.PaymentMode;
               
                context.SaveChanges();
                status = true;
            }
            return status;
        }
    }
}