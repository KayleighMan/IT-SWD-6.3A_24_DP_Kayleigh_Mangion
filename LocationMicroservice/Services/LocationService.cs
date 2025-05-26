using LocationMicroservice.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Text.Json;

namespace LocationMicroservice.Services
{
    public class LocationService : InterfaceLocationService
    {
        private readonly IMongoCollection<Location> _locationCollection;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiHost;

        public LocationService(IOptions<MongoDbSettings> dbSettings, IConfiguration config, HttpClient httpClient)
        {
            var client = new MongoClient(dbSettings.Value.ConnectionString);
            var database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _locationCollection = database.GetCollection<Location>(dbSettings.Value.LocationCollectionName);

            _httpClient = httpClient;

            _apiKey = config["WeatherApi:Key"];
            _apiHost = config["WeatherApi:Host"];

            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _apiHost);
        }

        public async Task<Location> AddLocationAsync(Location loc)
        {
            await _locationCollection.InsertOneAsync(loc);
            return loc;
        }

        public async Task<Location> UpdateLocationAsync(Location loc)
        {
            await _locationCollection.ReplaceOneAsync(x => x.Id == loc.Id, loc);
            return loc;
        }

        public async Task<bool> DeleteLocationAsync(string id)
        {
            var result = await _locationCollection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }

        public async Task<List<Location>> GetLocationsByEmailAsync(string email)
        {
            return await _locationCollection.Find(x => x.Email == email).ToListAsync();
        }

        public async Task<string> GetWeatherAsync(string city)
        {
            var url = $"https://{_apiHost}/current.json?q={city}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // throws if not 200 OK
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
