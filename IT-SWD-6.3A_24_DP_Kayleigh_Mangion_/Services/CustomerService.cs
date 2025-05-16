using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CustomerMicroservice.Models;

namespace CustomerMicroservice.Services
{
    public class CustomerService : InterfaceCustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _customers = database.GetCollection<Customer>(settings.Value.CustomerCollectionName);
        }

        public async Task<bool> RegisterAsync(Customer customer)
        {
            var exists = await _customers.Find(x => x.Email == customer.Email).AnyAsync();
            if (exists) return false;

            customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password); // hash here
            await _customers.InsertOneAsync(customer);
            return true;
        }


        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = await _customers.Find(x => x.Email == email).FirstOrDefaultAsync();
            if (user == null)
                return false;

            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }


        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await _customers.Find(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
