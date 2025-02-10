using ProductWebApi.Model;
using ProductWebApi.Repository;

namespace ProductWebApi.Service
{
    public class PaymentService : IPaymentSevice
    {
        private readonly IPaymentRepo _paymentRepo;
        public PaymentService(IPaymentRepo repo)
        {
            this._paymentRepo=repo;
        }
        public bool Delete(int id)
        {
            bool status=_paymentRepo.Delete(id);
            return status;
        }

        public Payment GetPaymentById(int id)
        {
            Payment payment=_paymentRepo.GetPaymentById(id);
            return payment;
        }

        public List<Payment> GetPayments()
        {
            List<Payment> payments=_paymentRepo.GetPayments();
            return payments;
        }

        public bool Insert(Payment payment)
        {
            bool status=_paymentRepo.Insert(payment);
            return status;
        }

        public bool Update(Payment payment)
        {
            bool status=_paymentRepo.Update(payment);
            return status;
        }
    }
}