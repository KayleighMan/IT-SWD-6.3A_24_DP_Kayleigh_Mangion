namespace PaymentMicroservice.Models
{
    public class PaymentResponse
    {
        public string BookingId { get; set; }
        public double Total { get; set; }
        public DateTime PaidAt { get; set; }
    }

}
