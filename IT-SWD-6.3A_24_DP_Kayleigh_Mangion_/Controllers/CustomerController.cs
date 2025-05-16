using Microsoft.AspNetCore.Mvc;
using CustomerMicroservice.Models;
using CustomerMicroservice.Services;

namespace CustomerMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly InterfaceCustomerService _customerService;

        public CustomerController(InterfaceCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Customer customer)
        {
            bool result = await _customerService.RegisterAsync(customer);
            if (!result)
                return Conflict("Email already exists.");

            return Ok("Customer registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login loginData)
        {
            bool success = await _customerService.LoginAsync(loginData.Email, loginData.Password);
            if (!success)
                return Unauthorized("Invalid email or password.");

            return Ok("Login successful.");
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetCustomer(string email)
        {
            var customer = await _customerService.GetByEmailAsync(email);
            if (customer == null)
                return NotFound("Customer not found.");

            return Ok(customer);
        }
    }
}
