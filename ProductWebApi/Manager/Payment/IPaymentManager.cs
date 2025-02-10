using ProductWebApi.Model;

namespace ProductWebApi.Manager.Interface
{
    public interface IPaymentManager
    {
        List<Payment> GetPayments();
        Payment GetPaymentById(int id);
        bool Insert(Payment payment);
        bool Update(Payment payment);
        bool Delete(int id);
    }
}