using Microsoft.AspNetCore.Mvc;
using PaymentMicroservice.Models;
using PaymentMicroservice.Services;

namespace PaymentMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay([FromBody] Payment payment)
        {
            try
            {
                var result = await _paymentService.ProcessPaymentAsync(payment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("details/{bookingId}")]
        public async Task<IActionResult> GetPayment(string bookingId)
        {
            var result = await _paymentService.GetPaymentByBookingIdAsync(bookingId);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
