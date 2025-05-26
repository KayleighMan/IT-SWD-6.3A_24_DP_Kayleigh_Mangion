namespace Cab_Frontend.Models
{
    public class Payment
    {
        public string BookingId { get; set; } = string.Empty;
        public string CabType { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public int PassengerCount { get; set; }
        public double BaseFare { get; set; }
        public bool ApplyDiscount { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PaidAt { get; set; }
    }
}
