using ProductWebApi.Manager.Interface;
using ProductWebApi.Model;
namespace ProductWebApi.Manager
{
    public class PaymentManager : IPaymentManager
    {
        public bool Delete(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Payment GetPaymentById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Update(Payment payment)
        {
            throw new NotImplementedException();
        }
    }


}