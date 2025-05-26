using LocationMicroservice.Models;

namespace LocationMicroservice.Services
{
    public interface InterfaceLocationService
    {
        Task<Location> AddLocationAsync(Location loc);
        Task<Location> UpdateLocationAsync(Location loc);
        Task<bool> DeleteLocationAsync(string id);
        Task<List<Location>> GetLocationsByEmailAsync(string email);
        Task<string> GetWeatherAsync(string city);
    }
}
