namespace Cab_Frontend.Models
{
    public class BookingDto
    {
        public string? UserEmail { get; set; }
        public string? StartLocation { get; set; }
        public string? EndLocation { get; set; }
        public DateTime TripDateTime { get; set; }
        public int PassengerCount { get; set; }
        public string? CabType { get; set; }
        public string? Status { get; set; } 
    }
}
