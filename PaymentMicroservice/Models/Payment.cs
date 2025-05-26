using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PaymentMicroservice.Models
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string BookingId { get; set; }
        public string CabType { get; set; }
        public DateTime DateTime { get; set; }
        public int PassengerCount { get; set; }
        public double BaseFare { get; set; }
        public bool ApplyDiscount { get; set; }

        public double TotalPrice { get; set; }
        public DateTime PaidAt { get; set; }
    }
}
