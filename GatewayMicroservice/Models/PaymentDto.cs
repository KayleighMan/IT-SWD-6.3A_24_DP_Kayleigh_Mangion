namespace GatewayMicroservice.Models
{
    public class PaymentDto
    {
        public string BookingId { get; set; }
        public string CabType { get; set; }
        public DateTime DateTime { get; set; }
        public int PassengerCount { get; set; }
        public double BaseFare { get; set; }
        public bool ApplyDiscount { get; set; }
    }
}
