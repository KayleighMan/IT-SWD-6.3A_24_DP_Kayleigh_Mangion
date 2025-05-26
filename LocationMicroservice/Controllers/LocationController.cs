using LocationMicroservice.Models;
using LocationMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocationMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly InterfaceLocationService _service;

        public LocationController(InterfaceLocationService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Location loc) => Ok(await _service.AddLocationAsync(loc));

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Location loc) => Ok(await _service.UpdateLocationAsync(loc));

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id) =>
            await _service.DeleteLocationAsync(id) ? Ok() : NotFound();

        [HttpGet("all/{email}")]
        public async Task<IActionResult> GetByUser(string email) =>
            Ok(await _service.GetLocationsByEmailAsync(email));

        [HttpGet("weather/{city}")]
        public async Task<IActionResult> GetWeather(string city) =>
            Ok(await _service.GetWeatherAsync(city));
    }
}
