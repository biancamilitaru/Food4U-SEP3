using System.Threading.Tasks;
using Entities;

namespace Food4U_SEP3.Service.CustomerService
{
    public interface ICustomerServiceT2
    {
        Task<Customer> AddCustomerAsync(Customer customer);

        Task<Customer> ValidateLoginAsync(string username);

        Task<Customer> UpdateCustomerAsync(Customer customer, string username);
        
        Task DeleteCustomerAsync(string username);
    }
}