using ProductWebApi.Model;
using ProductWebApi.Repository;

namespace ProductWebApi.Service
{
    public class PaymentService : IPaymentSevice
    {
        private readonly IPaymentRepo _paymentRepo;
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Payment GetPaymentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPayments()
        {
            List<Payment> payments=_paymentRepo.GetPayments();
            return payments;
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