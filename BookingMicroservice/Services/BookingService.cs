using BookingMicroservice.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookingMicroservice.Services
{
    public class BookingService : InterfaceBookingService
    {
        private readonly IMongoCollection<Booking> _bookings;

        public BookingService(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _bookings = db.GetCollection<Booking>(settings.Value.BookingCollectionName);
        }

        public async Task CreateBookingAsync(Booking booking)
        {
            booking.Status = booking.TripDateTime > DateTime.Now ? "Current" : "Past";
            await _bookings.InsertOneAsync(booking);
        }

        public async Task<List<Booking>> GetCurrentBookingsAsync(string userEmail)
        {
            return await _bookings.Find(b =>
                b.UserEmail == userEmail &&
                b.TripDateTime >= DateTime.Today).ToListAsync();
        }

        public async Task<List<Booking>> GetPastBookingsAsync(string userEmail)
        {
            return await _bookings.Find(b =>
                b.UserEmail == userEmail &&
                b.TripDateTime < DateTime.Today).ToListAsync();
        }
    }
}
