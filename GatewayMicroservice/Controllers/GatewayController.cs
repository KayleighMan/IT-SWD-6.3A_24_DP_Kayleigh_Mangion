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


    }
}
