using System.Threading.Tasks;
using Entities;

namespace Client.Data.CustomerService
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(Customer customer);
        Task<Customer> ValidateCustomerAsync(string username, string password);
    }
}