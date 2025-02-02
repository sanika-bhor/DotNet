using paymentProcessingDemo.Models;

namespace paymentProcessingDemo.Repository.Interface
{
    public interface IPaymentRepo
    {
        List<Payment> GetAllPayment();
        Payment GetElementById();
        bool Insert();
        bool Update();
        bool Delete();
    }
}