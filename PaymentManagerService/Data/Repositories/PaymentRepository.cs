using PaymentManagerService.Models;

namespace PaymentManagerService.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private PaymentManagerDbContext _context;

        public PaymentRepository(PaymentManagerDbContext context)
        {
            _context = context;
        }

        public Payment CreatePayment(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            _context.Payments.Add(payment);
            return payment;
        }

        public void DeletePayment(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            _context.Payments.Remove(payment);
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        public Payment GetPaymentById(int id)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.Id == id);
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            return payment;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePayment(int id, Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            var paymentToUpdate = _context.Payments.FirstOrDefault(p => p.Id == id);
            if (paymentToUpdate == null)
            {
                throw new ArgumentNullException(nameof(paymentToUpdate));
            }
            paymentToUpdate.Amount = payment.Amount;
            paymentToUpdate.Currency = payment.Currency;
            paymentToUpdate.CardNumber = payment.CardNumber;
            paymentToUpdate.CardCVV = payment.CardCVV;
            paymentToUpdate.CardExpirationDate = payment.CardExpirationDate;
            paymentToUpdate.UserId = payment.UserId;
        }
    }
}
