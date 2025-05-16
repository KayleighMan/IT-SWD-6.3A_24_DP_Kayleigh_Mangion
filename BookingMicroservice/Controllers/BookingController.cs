using Microsoft.AspNetCore.Mvc;
using BookingMicroservice.Models;
using BookingMicroservice.Services;

namespace BookingMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly InterfaceBookingService _bookingService;

        public BookingController(InterfaceBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            await _bookingService.CreateBookingAsync(booking);
            return Ok("Booking created successfully.");
        }

        [HttpGet("current/{email}")]
        public async Task<IActionResult> GetCurrentBookings(string email)
        {
            var bookings = await _bookingService.GetCurrentBookingsAsync(email);
            return Ok(bookings);
        }

        [HttpGet("past/{email}")]
        public async Task<IActionResult> GetPastBookings(string email)
        {
            var bookings = await _bookingService.GetPastBookingsAsync(email);
            return Ok(bookings);
        }
    }
}
