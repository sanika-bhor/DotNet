using paymentProcessingDemo.Models;

namespace paymentProcessingDemo.Repository.Interface
{
    public interface IPaymentRepo
    {
        List<Payment> GetAllPayment();
        Payment GetElementById(int id);
        bool Insert(Payment payment);
        bool Update(Payment payment);
        bool Delete(int id);
    }
}