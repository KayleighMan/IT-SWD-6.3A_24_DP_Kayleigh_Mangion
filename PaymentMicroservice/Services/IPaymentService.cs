using PaymentMicroservice.Models;

namespace PaymentMicroservice.Services
{
    public interface IPaymentService
    {
        Task<Payment> ProcessPaymentAsync(Payment payment);
        Task<Payment> GetPaymentByBookingIdAsync(string bookingId);
    }
}
