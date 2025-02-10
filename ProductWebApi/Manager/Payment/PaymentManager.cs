using ProductWebApi.Manager.Interface;
using ProductWebApi.Model;
namespace ProductWebApi.Manager
{
    public class PaymentManager : IPaymentManager
    {
        public bool Delete(int id)
        {
            bool status = false;
            using (var context = new CollectionContext())
            {
                context.Payments.Remove(context.Payments.Find(id));
                context.SaveChanges();
                status = true;
            }
            return status;
        }

        public Payment GetPaymentById(int id)
        {
            using(var context=new CollectionContext())
            {
                Payment payment=context.Payments.Find(id);
                return payment;
            }
        }

        public List<Payment> GetPayments()
        {
            using (var context=new CollectionContext())
            {
                return context.Payments.ToList<Payment>();
            }
        }

        public bool Insert(Payment payment)
        {
            bool status=false;
            using(var context=new CollectionContext())
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
                Payment payment1=context.Payments.Find(payment.Id);
                payment1.OrderId=payment.OrderId;
                payment1.Amount=payment.Amount;
                payment1.PaymentDate=payment.PaymentDate;
                payment1.PaymentMode=payment.PaymentMode;
                context.SaveChanges();
                status = true;
            }
            return status;
        }
    }


}