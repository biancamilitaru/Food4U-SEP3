using System.Threading.Tasks;
using Entities;

namespace Client.Data.CustomerService
{
    public interface ICustomerServiceT1
    {
        Task AddCustomerAsync(Customer customer);
        
        Task<Customer> GetCustomerAsync(string username);
        Task<Customer> ValidateCustomerAsync(string username, string password);

        Task UpdateCustomerAsync(Customer customer);
        
        Task DeleteCustomerAsync(string username); 
    }
}