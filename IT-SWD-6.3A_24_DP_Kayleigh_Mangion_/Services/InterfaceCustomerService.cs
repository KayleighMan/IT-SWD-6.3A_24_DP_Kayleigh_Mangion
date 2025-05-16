using CustomerMicroservice.Models;

namespace CustomerMicroservice.Services
{
    public interface InterfaceCustomerService
    {
        Task<bool> RegisterAsync(Customer customer);
        Task<bool> LoginAsync(string email, string password); 
        Task<Customer> GetByEmailAsync(string email);
    }
}
