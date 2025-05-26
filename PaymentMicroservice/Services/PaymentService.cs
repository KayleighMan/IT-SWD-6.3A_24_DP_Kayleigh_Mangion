using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PaymentMicroservice.Models;

namespace PaymentMicroservice.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMongoCollection<Payment> _paymentCollection;

        public PaymentService(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            _paymentCollection = db.GetCollection<Payment>(settings.Value.PaymentCollectionName);
        }

        public async Task<Payment> ProcessPaymentAsync(Payment p)
        {
            double cabMultiplier = p.CabType switch
            {
                "Premium" => 1.2,
                "Executive" => 1.4,
                _ => 1.0
            };

            double timeMultiplier = (p.DateTime.TimeOfDay < TimeSpan.FromHours(8)) ? 1.2 : 1.0;

            double passengerMultiplier = p.PassengerCount switch
            {
                <= 4 => 1.0,
                <= 8 => 2.0,
                _ => throw new ArgumentException("Too many passengers")
            };

            double discount = p.ApplyDiscount ? 0.9 : 1.0;

            p.TotalPrice = Math.Round(p.BaseFare * cabMultiplier * timeMultiplier * passengerMultiplier * discount, 2);
            p.PaidAt = DateTime.UtcNow;

            await _paymentCollection.InsertOneAsync(p);
            return p;
        }

        public async Task<Payment> GetPaymentByBookingIdAsync(string bookingId)
        {
            return await _paymentCollection.Find(p => p.BookingId == bookingId).FirstOrDefaultAsync();
        }
    }
}
