using BookingMicroservice.Models;

namespace BookingMicroservice.Services
{
    public interface InterfaceBookingService
    {
        Task CreateBookingAsync(Booking booking);
        Task<List<Booking>> GetCurrentBookingsAsync(string userEmail);
        Task<List<Booking>> GetPastBookingsAsync(string userEmail);
    }
}
