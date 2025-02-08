using ProductWebApi.Model;

namespace ProductWebApi.Repository
{
    public interface IPaymentRepo
    {
          List<Payment> GetPayments();
        Payment GetPaymentById(int id);
        bool Insert(Payment payment);
        bool Update(Payment payment);
        bool Delete(int id);
    }
}