using paymentProcessingDemo.Models;
using paymentProcessingDemo.Repository.Interface;
using paymentProcessingDemo.Service.Interface;

namespace paymentProcessingDemo.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepo _paymentRepository;
        public PaymentService(IPaymentRepo paymentRepo)
        {
            this._paymentRepository=paymentRepo;
        }
        public bool Delete(int id)
        {
           bool status=_paymentRepository.Delete(id);
           return status;
        }

        public List<Payment> GetAllPayment()
        {
            List<Payment> payments=_paymentRepository.GetAllPayment();
            return payments;
        }

        public Payment GetElementById(int id)
        {
            Payment payment=_paymentRepository.GetElementById(id);
            return payment;
        }

        public bool Insert(Payment payment)
        {
            bool status=_paymentRepository.Insert(payment);
            return status;
        }

        public bool Update(Payment payment)
        {
            bool status =_paymentRepository.Update(payment);
            return status;
        }
    }
}