using PaymentManagerService.Models;

namespace PaymentManagerService.Data.Repositories
{
    public interface IPaymentRepository
    {
        bool SaveChanges();
        IEnumerable<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        Payment CreatePayment(Payment payment);
        void UpdatePayment(int id, Payment payment);
        void DeletePayment(Payment payment);
    }
}
