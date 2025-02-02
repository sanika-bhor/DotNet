using paymentProcessingDemo.Models;

namespace paymentProcessingDemo.Manager.Interface
{
    public interface IPaymentManager
    {
        List<Payment> GetAllPayment();
        Payment GetElementById(int id);
        bool Insert(Payment payment);
        bool Update(Payment payment);
        bool Delete(int id);
    }
}