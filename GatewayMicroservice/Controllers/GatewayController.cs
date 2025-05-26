using GatewayMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace GatewayMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GatewayController : ControllerBase
    {
        private readonly HttpClient _http;

        public GatewayController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
        }

        // --------------------- Customer ---------------------

        [HttpPost("customer/register")]
        public async Task<IActionResult> Register([FromBody] CustomerRegisterDto customer)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:7114/api/Customer/register", customer);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpPost("customer/login")]
        public async Task<IActionResult> Login([FromBody] CustomerLoginDto login)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:7114/api/Customer/login", login);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        // --------------------- Booking ---------------------
        [HttpPost("booking/create")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto booking)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:7085/api/Booking/create", booking);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("booking/current/{email}")]
        public async Task<IActionResult> GetCurrentBookings(string email)
        {
            var response = await _http.GetAsync($"https://localhost:7085/api/Booking/current/{email}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("booking/past/{email}")]
        public async Task<IActionResult> GetPastBookings(string email)
        {
            var response = await _http.GetAsync($"https://localhost:7085/api/Booking/past/{email}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        // --------------------- Payment --------------
        [HttpPost("payment/pay")]
        public async Task<IActionResult> MakePayment([FromBody] PaymentDto payment)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:7057/api/Payment/pay", payment);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("payment/details/{bookingId}")]
        public async Task<IActionResult> GetPaymentDetails(string bookingId)
        {
            var response = await _http.GetAsync($"https://localhost:7057/api/Payment/details/{bookingId}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        // --------------------- Location ------------------

        [HttpPost("location/add")]
        public async Task<IActionResult> AddLocation([FromBody] LocationDto loc)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:7077/api/Location/add", loc);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpPut("location/update")]
        public async Task<IActionResult> UpdateLocation([FromBody] LocationDto loc)
        {
            var response = await _http.PutAsJsonAsync("https://localhost:7077/api/Location/update", loc);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpDelete("location/delete/{id}")]
        public async Task<IActionResult> DeleteLocation(string id)
        {
            var response = await _http.DeleteAsync($"https://localhost:7077/api/Location/delete/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("location/all/{email}")]
        public async Task<IActionResult> GetLocations(string email)
        {
            var response = await _http.GetAsync($"https://localhost:7077/api/Location/all/{email}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("location/weather/{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            var response = await _http.GetAsync($"https://localhost:7077/api/Location/weather/{city}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

    }
}
