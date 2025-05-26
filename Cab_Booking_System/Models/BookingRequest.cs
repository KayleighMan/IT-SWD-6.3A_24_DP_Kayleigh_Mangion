using System.ComponentModel.DataAnnotations;

namespace Cab_Frontend.Models
{

    public class BookingRequest
    {
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "Start location is required")]
        public string? StartLocation { get; set; }

        [Required(ErrorMessage = "End location is required")]
        public string? EndLocation { get; set; }

        [Required]
        public DateTime TripDateTime { get; set; } = DateTime.Now;

        [Range(1, 8, ErrorMessage = "Passenger count must be between 1 and 8")]
        public int PassengerCount { get; set; }

        [Required(ErrorMessage = "Please select a cab type")]
        public string? CabType { get; set; }
    }
}