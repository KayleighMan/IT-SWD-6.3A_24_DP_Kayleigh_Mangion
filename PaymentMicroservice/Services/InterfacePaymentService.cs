using PaymentMicroservice.Models;

namespace PaymentMicroservice.Services
{
    public interface InterfacePaymentService
    {
        Task<Payment> ProcessPaymentAsync(Payment payment);
        Task<Payment> GetPaymentByBookingIdAsync(string bookingId);
    }
}
