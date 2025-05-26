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

    }
}
